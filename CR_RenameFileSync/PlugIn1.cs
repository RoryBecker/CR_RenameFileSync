using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_RenameFileSync
{
	public partial class PlugIn1 : StandardPlugIn
	{
		bool insideRename;
		Dictionary<string, string> originalClassNames = new Dictionary<string, string>();

		// DXCore-generated code...
		#region InitializePlugIn
		public override void InitializePlugIn()
		{
			base.InitializePlugIn();
		}
		#endregion
		#region FinalizePlugIn
		public override void FinalizePlugIn()
		{
			//
			// TODO: Add your finalization code here.
			//

			base.FinalizePlugIn();
		}
		#endregion

		bool IsTypeRename(LinkedIdentifierEventArgs ea)
		{
			TypeDeclaration typeAtRename = ea.LinkedIdentifier.File.GetNodeAt(ea.LinkedIdentifier.Range.Start) as TypeDeclaration;
			if (typeAtRename != null)
				return typeAtRename.NameRange == ea.LinkedIdentifier.Range;
			return false;
		}

		private void PlugIn1_LinkedIdentifierActivated(LinkedIdentifierEventArgs ea)
		{
            RefactoringProviderBase activeRefactoring = CodeRush.Refactoring.Active;
            insideRename = activeRefactoring != null && activeRefactoring.DisplayName == "Rename";
			if (!insideRename || !IsTypeRename(ea))
				return;
			string text = ea.LinkedIdentifier.Text;
			SourceFile file = ea.LinkedIdentifier.File;
			string fullPath = file.FilePath;
			string rootName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
			while (rootName.IndexOf(".") >= 0)
				rootName = System.IO.Path.GetFileNameWithoutExtension(rootName);
			if (rootName == text)
				if (!originalClassNames.ContainsKey(fullPath))
					originalClassNames.Add(fullPath, text);
		}

		private void PlugIn1_LinkedIdentifierDeactivated(LinkedIdentifierEventArgs ea)
		{
			TypeDeclaration typeAtRename = ea.LinkedIdentifier.File.GetNodeAt(ea.LinkedIdentifier.Range.Start) as TypeDeclaration;
			if (typeAtRename == null)
				return;

			SourceFile file = ea.LinkedIdentifier.File;
			string text = ea.LinkedIdentifier.Text;

			string fullPath = file.FilePath;
			string rootName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
			while (rootName.IndexOf(".") >= 0)
				rootName = System.IO.Path.GetFileNameWithoutExtension(rootName);
			if (rootName != text)
				if (originalClassNames.ContainsKey(fullPath))
				{
					RenameFile(file, text);
				}
		}

		void RenameFile(SourceFile file, string newName)
		{
			 CodeRush.Language.ParseActiveDocument();
			RefactoringProviderBase renameFile = CodeRush.Refactoring.Get("Rename File to Match Type");
            
			if (renameFile != null)
			{
                if(renameFile.IsAvailable)
                    renameFile.Execute();
				return;
			}
		}
	}
}