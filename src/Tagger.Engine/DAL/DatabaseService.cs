﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagger.Engine.DAL
{
    public static class DatabaseService
    {
        private static IDatabase _serviceInstance;
        private static FileRepository _fileRepo;

        static DatabaseService()
        {
        }

        public static void RegisterInstance(IDatabase instance)
        {
            _serviceInstance = instance;
            _serviceInstance.Init();
        }

        public static IDatabase GetInstance()
        {
            return _serviceInstance;
        }

        internal static FileRepository FileRepository
        {
            get
            {
                if (_fileRepo == null)
                {
                    if (GetInstance() == null)
                    {
                        throw new InvalidOperationException("Database is not specified");
                    }

                    _fileRepo = new FileRepository();
                    _fileRepo.Initialize();
                }

                return _fileRepo;
            }
        }
        
    }
}
