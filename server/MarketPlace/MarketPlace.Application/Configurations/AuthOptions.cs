﻿namespace MarketPlace.Application.Configurations
{
    public class AuthOptions
    {
        public string issuer { get; } = "MarketPlaceServer";
        public string audience { get; } = "MarketPlaceClient";
        public string key { get; } = "test,test,test,test,test,test123456789123456789123456789";
        public int lifetime { get; } = 12;
    }
}