﻿using System;
using Warden.Common.DTO.Common;
using Warden.Common.DTO.Watchers;

namespace Warden.Common.DTO.Wardens
{
    public class WardenCheckResultDto
    {
        public bool IsValid { get; set; }
        public WatcherCheckResultDto WatcherCheckResult { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public ExceptionDto Exception { get; set; }
    }
}