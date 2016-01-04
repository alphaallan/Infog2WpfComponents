using System.Windows;

namespace InfoG2WpfControls.DragDrop
{
    public interface IDropTargetAdvisor
    {
        UIElement TargetUI { get; set; }

        bool ApplyMouseOffset { get; }
        bool IsValidDataObject(IDataObject obj);
        void OnDropCompleted(IDataObject obj, Point dropPoint);
        UIElement GetVisualFeedback(IDataObject obj);
        UIElement GetTopContainer();
    }
}
