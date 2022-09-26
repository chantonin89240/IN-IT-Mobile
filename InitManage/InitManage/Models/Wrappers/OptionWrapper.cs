﻿using System;
using InitManage.Models.Interfaces;
using ReactiveUI;

namespace InitManage.Models.Wrappers;

public class OptionWrapper : ReactiveObject, IOption
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long TypeId { get; set; }


    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => this.RaiseAndSetIfChanged(ref _isSelected, value);
    }



    public OptionWrapper()
    {
    }

    public OptionWrapper(long id, string name, long typeId, bool isSelected)
    {
        Id = id;
        Name = name;
        TypeId = typeId;
        IsSelected = isSelected;
    }

    public OptionWrapper(IOption option)
    {
        Id = option.Id;
        Name = option.Name;
        TypeId = option.TypeId;
    }
}

