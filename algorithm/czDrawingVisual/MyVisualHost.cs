using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace czDrawingVisual
{
   // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual objects.
    public class MyVisualHost : FrameworkElement
    {
        // Create a collection of child visual objects.
        private VisualCollection _children;

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }

        public MyVisualHost()
        {
            _children = new VisualCollection(this);
            _children.Add(CreateDrawingVisualRectangle());
            //_children.Add(CreateDrawingVisualText());
            //_children.Add(CreateDrawingVisualEllipses());

            // Add the event handler for MouseLeftButtonUp.
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
        }

        // Create a DrawingVisual that contains a rectangle.
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);

            // Persist the drawing content.
            drawingContext.Close();

            drawingVisual.HitTest(null, czCallback, new PointHitTestParameters(new Point(0,0)));

            return drawingVisual;
        }



        public HitTestResultBehavior czCallback(HitTestResult result)// not worked 
        {
            MessageBox.Show("点击了矩形");

            return HitTestResultBehavior.Stop;
        }

        // WPF命中测试的例子
        //http://www.cnblogs.com/SkyD/archive/2010/05/10/1731646.html
        //http://www.cnblogs.com/SkyD/archive/2010/05/17/1737106.html


        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retreive the coordinates of the mouse button event.
            System.Windows.Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
            VisualTreeHelper.HitTest(this, null, 
                f =>
                {
                    var o = f.VisualHit as DrawingVisual;
                    if (o != null)
                        MessageBox.Show("hit");
                    return HitTestResultBehavior.Continue;
                },
                new GeometryHitTestParameters(new RectangleGeometry(new Rect(new Point(0,0),new Point(500,500)))));

        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                MessageBox.Show("hit0");
                if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 0.1;
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 1.0;
                }
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Continue;
        }
    }
}
