using System.ComponentModel.Composition;
using DevExpress.CodeRush.Common;

namespace CR_RenameFileSync
{
    [Export(typeof(IVsixPluginExtension))]
    public class CR_RenameFileSyncExtension : IVsixPluginExtension { }
}