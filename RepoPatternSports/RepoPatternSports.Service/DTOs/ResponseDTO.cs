﻿namespace RepoPatternSports.Service.DTOs
{
    public class ResponseDTO
    {
        public int Status { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; }
        public string? Error { get; set; }
    }
}
