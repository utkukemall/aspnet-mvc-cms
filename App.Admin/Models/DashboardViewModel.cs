﻿namespace App.Admin.Models
{
    internal class DashboardViewModel
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public int? DoctorCount { get; set; }
        public int? PatientCount { get; set; }
        public int? UserCount { get; set; }
        public int? AppointmentCount { get; set; }
        public int? ContactCount { get; set; }
        public int? DepartmentCount { get; set; }
        public int? DepartmentsPostsCount { get; set; }
        public int? PostCount { get; set; }
        public int? SubscriberCount { get; set; }
        public int? PostCommentsCount { get; set; }
        public int? RoleCount { get; set; }
        public int? SettingsCount { get; set; }
    }
}