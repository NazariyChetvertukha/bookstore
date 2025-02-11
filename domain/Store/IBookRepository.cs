﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsdn(string isdn);
        
        Book[] GetAllByTitleOrAuthor(string query);
        
        Book GetById(in int id);


        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
