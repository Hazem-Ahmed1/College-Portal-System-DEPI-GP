﻿using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Create context reference here 
        private readonly AppDbContext _context;
        public IStudentRepo StudentRepo { get; private set; }
        public IBaseRepository<ApplicationUser> ApplicationUserRepo {  get; private set; }
        public IBaseRepository<CourseEnrollment> CourseEnrollmentRepo {  get; private set; }
        public IBaseRepository<Department> DepartmentRepo {  get; private set; }
        public IBaseRepository<Course> CourseRepo {  get; private set; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            StudentRepo = new StudentRepo(_context);
            ApplicationUserRepo = new BaseRepository<ApplicationUser>(_context);
            CourseEnrollmentRepo = new BaseRepository<CourseEnrollment>(_context);
            DepartmentRepo = new BaseRepository<Department>(_context);
            CourseRepo = new BaseRepository<Course>(_context);

        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
