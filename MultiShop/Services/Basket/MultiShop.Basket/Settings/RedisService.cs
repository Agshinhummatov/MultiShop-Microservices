﻿using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }

        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer; // Redise baglanmaq ucun istifade olunur
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) =>_connectionMultiplexer.GetDatabase(0); // burda ise biz neynirik Redisde 16 dene db var 1 cin secirik yeni 0 ci indexde durani 
    }
}