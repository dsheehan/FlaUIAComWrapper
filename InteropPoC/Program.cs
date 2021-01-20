using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.UIA3;
using FlaUI.UIA3.Converters;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.Mappings;
using TestStack.White.UIItems.Actions;

namespace InteropPoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // FlaUI
            var automation = new UIA3Automation();
            FlaUI.Core.AutomationElements.AutomationElement desktopFlaUI = automation.GetDesktop();
            Console.WriteLine("FlaUI Desktop= " + desktopFlaUI.Name);

            // TestStack.White
            TestStack.White.UIItems.IUIItem desktopTestStackWhite = Desktop.Instance;
            Console.WriteLine("TestStack.White Desktop=" + desktopTestStackWhite.Name);

            // conversion between the two
            TestStack.White.UIItems.IUIItem convertedToTestStackWhite = desktopFlaUI.Convert();
            Console.WriteLine("Converted from FlaUI to TestStack.White Desktop=" + convertedToTestStackWhite.Name);

            FlaUI.Core.AutomationElements.AutomationElement convertedToFlaUI = desktopTestStackWhite.Convert();
            Console.WriteLine("Converted from TestStack.White to FlaUI Desktop=" + convertedToFlaUI.Name);
        }
    }

    public static class ConversionUtil
    {
        public static FlaUI.Core.AutomationElements.AutomationElement Convert(this TestStack.White.UIItems.IUIItem item)
        {
            var native = item.AutomationElement.NativeElement;
            var automation = new UIA3Automation();
            return automation.WrapNativeElement(native);
        }

        public static TestStack.White.UIItems.IUIItem Convert(this FlaUI.Core.AutomationElements.AutomationElement element, IActionListener listener = null)
        {
            var native = element.ToNative();
            var managed = System.Windows.Automation.AutomationElement.Wrap(native);
            var factory = new DictionaryMappedItemFactory();
            listener = listener ?? new NullActionListener();
            try
            {
                return factory.Create(managed, listener);
            }
            catch (ControlDictionaryException)
            {
                return new TestStack.White.UIItems.UIItem(managed, listener);
            }
        }
    }
}
