namespace filemanager
{
    public partial class Manager
    {
        private void InitializeUserControllerEvents(Mediator mediator)
        {
            Controllers["QuickAccessAdd"].Click     += (sender, e) => AccessAdd(mediator);
            Controllers["QuickAccessRemove"].Click  += (sender, e) => AccessRemove();
            Controllers["CompareNames"].Click       += (sender, e) => CompareFilenames(mediator);
            Controllers["ChangeAttributes"].Click   += (sender, e) => mediator.ChangeAttributes();
            Controllers["OpenInExplorer"].Click     += (sender, e) => mediator.OpenInExplorer();
            Controllers["SaveSelection"].Click      += (sender, e) => mediator.SaveSelection();
            Controllers["RestoreSelection"].Click   += (sender, e) => mediator.RestoreSelection();
            Controllers["SelectionToFile"].Click    += (sender, e) => mediator.SelectionToFile();
            Controllers["LoadSelectionFile"].Click  += (sender, e) => mediator.LoadSelectionFromFile();
            Controllers["InvertSelection"].Click    += (sender, e) => mediator.InvertSelection();
            Controllers["SortName"].Click           += (sender, e) => mediator.Sort(SortType.name);
            Controllers["SortDate"].Click           += (sender, e) => mediator.Sort(SortType.date);
            Controllers["SortSize"].Click           += (sender, e) => mediator.Sort(SortType.size);
            Controllers["SortExtension"].Click      += (sender, e) => mediator.Sort(SortType.extension);
            Controllers["SortReversed"].Click       += (sender, e) => mediator.ReverseSort(reversedTool.Checked);
            Controllers["OpenConsole"].Click        += (sender, e) => mediator.Console();
            Controllers["OpenPowershell"].Click     += (sender, e) => mediator.PowerShell();
            Controllers["ViewDetails"].Click        += (sender, e) => mediator.SetView(1);
            Controllers["ViewSmallIcons"].Click     += (sender, e) => mediator.SetView(2);
            Controllers["ViewList"].Click           += (sender, e) => mediator.SetView(3);
            Controllers["ViewTiles"].Click          += (sender, e) => mediator.SetView(4);
            Controllers["GoUp"].Click               += (sender, e) => mediator.GoUp();
            Controllers["Print"].Click              += (sender, e) => mediator.Print();
            Controllers["SearchFor"].Click          += (sender, e) => mediator.SearchFor();
            Controllers["ShowAllFiles"].Click       += (sender, e) => mediator.ShowAll();
            Controllers["ShowPrograms"].Click       += (sender, e) => mediator.ShowPrograms();
            Controllers["ShowCustom"].Click         += (sender, e) => mediator.ShowCustom();
            Controllers["CalculateSpace"].Click     += (sender, e) => mediator.CalculateSpace();
            Controllers["MultiRename"].Click        += (sender, e) => mediator.MultiRename();
            Controllers["SelectGroup"].Click        += (sender, e) => mediator.SetGroupSelection(true);
            Controllers["UnselectGroup"].Click      += (sender, e) => mediator.SetGroupSelection(false);
            Controllers["CreateTab"].Click          += (sender, e) => mediator.CreateTab(false, Click, mediator.DoubleClick, associated);
            Controllers["DeleteTab"].Click          += (sender, e) => mediator.DeleteTab();
            Controllers["SelectAll"].Click          += (sender, e) => mediator.SetSelection(true);
            Controllers["UnselectAll"].Click        += (sender, e) => mediator.SetSelection(false);
            Controllers["SelectExtensions"].Click   += (sender, e) => mediator.SelectAllWithTheSameExtension();
            Controllers["ClipSelected"].Click       += (sender, e) => mediator.CopyNamesToClipboard(false, false);
            Controllers["ClipWithPath"].Click       += (sender, e) => mediator.CopyNamesToClipboard(true, false);
            Controllers["ClipWithExtensions"].Click += (sender, e) => mediator.CopyNamesToClipboard(false, true);
            Controllers["ClipPathExtensions"].Click += (sender, e) => mediator.CopyNamesToClipboard(true, true);
            Controllers["Refresh"].Click            += (sender, e) => mediator.Refresh();
            Controllers["Rename"].Click             += (sender, e) => mediator.Rename();
            Controllers["View"].Click               += (sender, e) => mediator.DoubleClick(associated);
            Controllers["Edit"].Click               += (sender, e) => mediator.Edit();
            Controllers["NewFolder"].Click          += (sender, e) => mediator.NewFolder();
            Controllers["Delete"].Click             += (sender, e) => mediator.DeleteSelection();
            Controllers["PackZip"].Click            += (sender, e) => mediator.ZipSelected();
            Controllers["UnpackAll"].Click          += (sender, e) => mediator.UnzipSelected();
            Controllers["Copy"].Click               += (sender, e) => { if (mediator.IsDisplayFocused()) exchangeBuffer.Copy(mediator.GetSelectedItems()); exchangeBuffer.Cut = false; };
            Controllers["Cut"].Click                += (sender, e) => { if (mediator.IsDisplayFocused()) exchangeBuffer.Copy(mediator.GetSelectedItems()); exchangeBuffer.Cut = true; };
            Controllers["Paste"].Click              += (sender, e) => { if (mediator.IsDisplayFocused()) exchangeBuffer.Paste(mediator.GetRoot()); };
        }
    }
}