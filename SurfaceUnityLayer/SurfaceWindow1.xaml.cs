using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Globalization;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace SurfaceUnityLayer
{

    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        private myForm wf;
        private double oldSize = 3000*3000;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void wfThreadStart()
        {
            wf = new myForm();
            wf.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void SurfaceWindow_Loaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("<sdebug> loaded");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread wfThread = new Thread(new ThreadStart(wfThreadStart));
            wfThread.SetApartmentState(ApartmentState.STA);
            wfThread.IsBackground = true;
            System.Diagnostics.Debug.WriteLine("<sdebug> starting thread");
            wfThread.Start();

        }

        private void triggerDebugLog(string message)
        {
            if (wf != null)
            {
                System.Diagnostics.Debug.WriteLine("######## " + message);
                //wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", message);
            }
        }

        private void SurfaceWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        

        private void SurfaceWindow_TouchDown(object sender, TouchEventArgs e)
        {
        }

        private void SurfaceWindow_TouchLeave(object sender, TouchEventArgs e)
        {
        }


        private void scatterViewItem1_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            //triggerDebugLog("size changed");
            //triggerDebugLog(" ##new size : " + scatterViewItem1.Width + ", " + scatterViewItem1.Height);
            //double newSize = scatterViewItem1.Width * scatterViewItem1.Height;
            //if (newSize < oldSize)
            //    wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", "decrease");
            //else if (newSize > oldSize)
            //    wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", "increase");

            //oldSize = newSize;
        }

        private void scatterViewItem1_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void SurfaceWindow_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;

        }

        private void SurfaceWindow_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Point p = e.ManipulationOrigin;
            //triggerDebugLog("Manipulation started at " + p.ToString());

        }

        private void SurfaceWindow_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
         

            if (e.DeltaManipulation.Scale.X != 1.0) { // scaled
                string obj = "scale," +
                    e.DeltaManipulation.Scale.X.ToString() + "," +
                    e.DeltaManipulation.Scale.Y.ToString();

                if(wf != null)
                    wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", obj);

                
            }
            else if (e.DeltaManipulation.Translation.X != 0 ||
                e.DeltaManipulation.Translation.Y != 0) {
                    string obj = "translate," +
                        (e.DeltaManipulation.Translation.X*0.2).ToString() + "," +
                        (e.DeltaManipulation.Translation.Y*-0.2).ToString();
                    if (wf != null)
                    {
                        wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", obj);
                    }
            }

         //   triggerDebugLog("Manipulation Delta expansion - "+e.DeltaManipulation.Expansion.ToString());
           // triggerDebugLog("Manipulation Delta scale - " + e.DeltaManipulation.Scale.ToString());
            triggerDebugLog("Manipulation Delta translation - " + e.DeltaManipulation.Translation.ToString());
        }

        private void SurfaceWindow_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
        }

        private void SurfaceWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            triggerDebugLog("mouse up");
        }

        private void SurfaceWindow_TouchUp(object sender, TouchEventArgs e)
        {
            TouchPoint tp = e.GetTouchPoint(this);
            triggerDebugLog("touch up at : " +tp.Position.ToString());
            if (wf != null) { 
                string obj = "click," +
                    tp.Position.X.ToString() + "," +
                    tp.Position.Y.ToString();
                wf.axUnityWebPlayer1.SendMessage("surfaceControl", "surfaceFunction", obj);
            }
        }

        


    }
}