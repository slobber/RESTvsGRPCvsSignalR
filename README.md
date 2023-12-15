# RESTvsGRPCvsSignalR

Evaluating Performance of REST vs. gRPC vs. SignalR

## dotnet run --project RestAPI -c Release

Starts the ASP.NET Web REST API

## dotnet run --project GrpcAPI -c Release

Starts the GRPC Service

## dotnet run --project SignalRAPI -c Release

## dotnet run --project RESTvsGRPCvsSignalR -c Release

Runs the benchmark on the above services

# Benchmark for .NET 8

```ini

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

```

| Method                         | IterationCount |       Mean |      Error |     StdDev |     Median |
| ------------------------------ | -------------- | ---------: | ---------: | ---------: | ---------: |
| SignalRGetSmallPayloadAsync    | 100            |   5.771 ms |  0.0708 ms |  0.0662 ms |   5.780 ms |
| SignalRStreamSmallPayloadAsync | 100            |  64.871 ms |  0.7999 ms |  0.7482 ms |  64.948 ms |
| SignalRGetLargePayloadAsync    | 100            |  74.890 ms |  0.8284 ms |  0.7343 ms |  74.768 ms |
| SignalRPostLargePayloadAsync   | 100            |  90.270 ms |  0.3157 ms |  0.2465 ms |  90.214 ms |
| SignalRStreamLargePayloadAsync | 100            | 108.907 ms |  2.1761 ms |  3.6359 ms | 107.156 ms |
| RestGetSmallPayloadAsync       | 100            |   5.731 ms |  0.0446 ms |  0.0396 ms |   5.729 ms |
| RestGetLargePayloadAsync       | 100            | 301.027 ms |  5.7381 ms |  5.8926 ms | 298.377 ms |
| RestPostLargePayloadAsync      | 100            | 278.234 ms |  1.9258 ms |  1.7072 ms | 277.790 ms |
| GrpcGetSmallPayloadAsync       | 100            |   8.307 ms |  0.1638 ms |  0.1682 ms |   8.272 ms |
| GrpcStreamSmallPayloadAsync    | 100            | 384.605 ms |  7.0994 ms |  6.6408 ms | 385.175 ms |
| GrpcStreamLargePayloadAsync    | 100            | 437.844 ms |  7.6619 ms |  7.1669 ms | 437.198 ms |
| GrpcGetLargePayloadAsListAsync | 100            |  60.104 ms |  1.1641 ms |  1.2455 ms |  59.550 ms |
| GrpcPostLargePayloadAsync      | 100            |  53.883 ms |  0.7142 ms |  0.6681 ms |  53.974 ms |
|                                |                |            |            |            |            |
| SignalRGetSmallPayloadAsync    | 200            |  10.849 ms |  0.1898 ms |  0.1682 ms |  10.848 ms |
| SignalRStreamSmallPayloadAsync | 200            | 124.470 ms |  2.4575 ms |  3.6022 ms | 123.343 ms |
| SignalRGetLargePayloadAsync    | 200            | 145.863 ms |  2.1348 ms |  1.9969 ms | 145.710 ms |
| SignalRPostLargePayloadAsync   | 200            | 181.329 ms |  1.4608 ms |  1.2950 ms | 181.731 ms |
| SignalRStreamLargePayloadAsync | 200            | 223.131 ms |  1.1530 ms |  1.0221 ms | 223.349 ms |
| RestGetSmallPayloadAsync       | 200            |  11.515 ms |  0.0817 ms |  0.0638 ms |  11.516 ms |
| RestGetLargePayloadAsync       | 200            | 599.142 ms |  2.9831 ms |  2.4910 ms | 599.826 ms |
| RestPostLargePayloadAsync      | 200            | 558.694 ms |  3.0582 ms |  2.5537 ms | 558.019 ms |
| GrpcGetSmallPayloadAsync       | 200            |  15.927 ms |  0.1842 ms |  0.1723 ms |  15.882 ms |
| GrpcStreamSmallPayloadAsync    | 200            | 756.597 ms |  9.9115 ms |  9.2712 ms | 754.359 ms |
| GrpcStreamLargePayloadAsync    | 200            | 887.520 ms | 11.2676 ms | 10.5397 ms | 891.273 ms |
| GrpcGetLargePayloadAsListAsync | 200            | 100.166 ms |  0.9228 ms |  0.8181 ms | 100.184 ms |
| GrpcPostLargePayloadAsync      | 200            | 108.967 ms |  1.8341 ms |  1.7156 ms | 108.800 ms |
