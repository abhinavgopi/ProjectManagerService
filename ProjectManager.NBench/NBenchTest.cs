using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBench;
using ProjectManager.BLTest;

namespace ProjectManager.NBench
{
    public class NBenchTest
    {
        BLTest.BLTest blTest;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            blTest = new BLTest.BLTest();
        }
        [PerfBenchmark(Description = "ProjectManager Unit testing BenchingMarking",
            NumberOfIterations = 3,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 100,
            TestMode = TestMode.Measurement)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 70000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThanOrEqualTo, 4.0d)]
        public void Benchmark()
        {
            blTest.GetAllUser();
            blTest.GetAllTask();
            blTest.GetAllProject();
        }

        [PerfCleanup]
        public void Clean()
        {

        }
    }
}
