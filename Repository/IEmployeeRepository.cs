﻿namespace winery_backend.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetByUsername(string username);
        Employee GetById(int id);

        bool Create(Employee employee);

        bool Save();

        bool UsernameExist(string username);

        bool PhoneNumberExist(string phoneNumber);
        void Update(Employee employee);
    }
}
