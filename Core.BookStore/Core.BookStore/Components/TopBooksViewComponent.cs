﻿using Core.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Core.BookStore.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books=await _bookRepository.GetTopBooks(count);
            return View(books);
        }
    }
}
