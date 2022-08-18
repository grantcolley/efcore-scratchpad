﻿namespace EFCoreScratchPad.Model
{
    public class Redress
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}