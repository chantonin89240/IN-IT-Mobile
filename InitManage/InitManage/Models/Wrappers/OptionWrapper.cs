using System;
using System.Reactive;
using InitManage.Models.Interfaces;
using ReactiveUI;

namespace InitManage.Models.Wrappers;

public class OptionWrapper : ReactiveObject, IOption
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long TypeId { get; set; }

	#region IsSelected
	private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => this.RaiseAndSetIfChanged(ref _isSelected, value);
    }
	#endregion

	#region OptionTappedCommand
	public ReactiveCommand<Unit, Unit> OptionTappedCommand { get; private set; }
	private void OnOptionTappedCommand()
	{
		IsSelected = !IsSelected;
	}
	#endregion


	public OptionWrapper()
    {
		OptionTappedCommand = ReactiveCommand.Create(OnOptionTappedCommand);
	}

	public OptionWrapper(long id, string name, long typeId, bool isSelected) : this()
	{
        Id = id;
        Name = name;
        TypeId = typeId;
        IsSelected = isSelected;
    }

    public OptionWrapper(IOption option):this()
    {
        Id = option.Id;
        Name = option.Name;
        TypeId = option.TypeId;
    }
}

