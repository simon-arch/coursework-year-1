namespace filemanager
{
    public partial class Manager
    {
        private void InitializeUserControllerEvents(Mediator mediator)
        {
            _controllers["QuickAccessAdd"].Click     += (sender, e) => AccessAdd(mediator);
            _controllers["QuickAccessRemove"].Click  += (sender, e) => AccessRemove();
            _controllers["CompareNames"].Click       += (sender, e) => CompareFilenames(mediator);
            _controllers["ChangeAttributes"].Click   += (sender, e) => mediator.ChangeAttributes();
            _controllers["OpenInExplorer"].Click     += (sender, e) => mediator.OpenInExplorer();
            _controllers["SaveSelection"].Click      += (sender, e) => mediator.SaveSelection();
            _controllers["RestoreSelection"].Click   += (sender, e) => mediator.RestoreSelection();
            _controllers["SelectionToFile"].Click    += (sender, e) => mediator.SelectionToFile();
            _controllers["LoadSelectionFile"].Click  += (sender, e) => mediator.LoadSelectionFromFile();
            _controllers["InvertSelection"].Click    += (sender, e) => mediator.InvertSelection();
            _controllers["SortName"].Click           += (sender, e) => mediator.Sort(SortType.name);
            _controllers["SortDate"].Click           += (sender, e) => mediator.Sort(SortType.date);
            _controllers["SortSize"].Click           += (sender, e) => mediator.Sort(SortType.size);
            _controllers["SortExtension"].Click      += (sender, e) => mediator.Sort(SortType.extension);
            _controllers["SortReversed"].Click       += (sender, e) => mediator.ReverseSort(reversedTool.Checked);
            _controllers["OpenConsole"].Click        += (sender, e) => mediator.Console();
            _controllers["OpenPowershell"].Click     += (sender, e) => mediator.PowerShell();
            _controllers["ViewDetails"].Click        += (sender, e) => mediator.SetView(1);
            _controllers["ViewSmallIcons"].Click     += (sender, e) => mediator.SetView(2);
            _controllers["ViewList"].Click           += (sender, e) => mediator.SetView(3);
            _controllers["ViewTiles"].Click          += (sender, e) => mediator.SetView(4);
            _controllers["GoUp"].Click               += (sender, e) => mediator.GoUp();
            _controllers["Print"].Click              += (sender, e) => mediator.Print();
            _controllers["SearchFor"].Click          += (sender, e) => mediator.SearchFor();
            _controllers["ShowAllFiles"].Click       += (sender, e) => mediator.ShowAll();
            _controllers["ShowPrograms"].Click       += (sender, e) => mediator.ShowPrograms();
            _controllers["ShowCustom"].Click         += (sender, e) => mediator.ShowCustom();
            _controllers["CalculateSpace"].Click     += (sender, e) => mediator.CalculateSpace();
            _controllers["MultiRename"].Click        += (sender, e) => mediator.MultiRename();
            _controllers["SelectGroup"].Click        += (sender, e) => mediator.SetGroupSelection(true);
            _controllers["UnselectGroup"].Click      += (sender, e) => mediator.SetGroupSelection(false);
            _controllers["CreateTab"].Click          += (sender, e) => mediator.CreateTab(false, Click, mediator.DoubleClick, _associated);
            _controllers["DeleteTab"].Click          += (sender, e) => mediator.DeleteTab();
            _controllers["SelectAll"].Click          += (sender, e) => mediator.SetSelection(true);
            _controllers["UnselectAll"].Click        += (sender, e) => mediator.SetSelection(false);
            _controllers["SelectExtensions"].Click   += (sender, e) => mediator.SelectAllWithTheSameExtension();
            _controllers["ClipSelected"].Click       += (sender, e) => mediator.CopyNamesToClipboard(false, false);
            _controllers["ClipWithPath"].Click       += (sender, e) => mediator.CopyNamesToClipboard(true, false);
            _controllers["ClipWithExtensions"].Click += (sender, e) => mediator.CopyNamesToClipboard(false, true);
            _controllers["ClipPathExtensions"].Click += (sender, e) => mediator.CopyNamesToClipboard(true, true);
            _controllers["Refresh"].Click            += (sender, e) => mediator.Refresh();
            _controllers["Rename"].Click             += (sender, e) => mediator.Rename();
            _controllers["View"].Click               += (sender, e) => mediator.DoubleClick(_associated);
            _controllers["Edit"].Click               += (sender, e) => mediator.Edit();
            _controllers["NewFolder"].Click          += (sender, e) => mediator.NewFolder();
            _controllers["Delete"].Click             += (sender, e) => mediator.DeleteSelection();
            _controllers["PackZip"].Click            += (sender, e) => mediator.ZipSelected();
            _controllers["UnpackAll"].Click          += (sender, e) => mediator.UnzipSelected();
            _controllers["Copy"].Click               += (sender, e) => { if (mediator.IsDisplayFocused()) _exchangeBuffer.Copy(mediator.GetSelectedItems()); _exchangeBuffer.Cut = false; };
            _controllers["Cut"].Click                += (sender, e) => { if (mediator.IsDisplayFocused()) _exchangeBuffer.Copy(mediator.GetSelectedItems()); _exchangeBuffer.Cut = true; };
            _controllers["Paste"].Click              += (sender, e) => { if (mediator.IsDisplayFocused()) _exchangeBuffer.Paste(mediator.GetRoot()); };
        }
    }
}