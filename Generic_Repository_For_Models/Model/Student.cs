﻿namespace GenericRepository.Model
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int Marks{ get; set; }
    }
}
