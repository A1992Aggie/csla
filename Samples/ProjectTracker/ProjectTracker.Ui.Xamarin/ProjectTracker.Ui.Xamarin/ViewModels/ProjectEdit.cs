using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Library;
using System.Windows.Input;
using Xamarin.Forms;
using Csla.Xaml;

namespace XamarinFormsUi.ViewModels
{
  public class ProjectEdit : ViewModel<ProjectTracker.Library.ProjectEdit>
  {
    public ICommand SaveItemCommand { get; private set; }
    public ICommand AssignResourceCommand { get; private set; }

    private int ProjectId { get; set; }

    public ProjectEdit(int projectId)
    {
      SaveItemCommand = new Command(async () => await SaveAsync());
      AssignResourceCommand = new Command(() => { });
      ProjectId = projectId;
    }

    protected override void OnModelChanged(ProjectTracker.Library.ProjectEdit oldValue, ProjectTracker.Library.ProjectEdit newValue)
    {
      base.OnModelChanged(oldValue, newValue);
      try
      {
        _nameInfo = new PropertyInfo { BindingContext = newValue, Path = "Name" };
      }
      catch (Exception ex)
      {
        var x = ex;
      }
    }

    private PropertyInfo _nameInfo = new PropertyInfo();
    public PropertyInfo NameInfo
    {
      get { return _nameInfo; }
    }

    protected override async Task<ProjectTracker.Library.ProjectEdit> DoInitAsync()
    {
      var obj = await ProjectTracker.Library.ProjectEdit.GetProjectAsync(ProjectId);
      try
      {
        _nameInfo = new PropertyInfo { BindingContext = obj, Path = "Name" };
      }
      catch (Exception ex)
      {
        var x = ex;
      }
      return obj;
    }
  }
}
