﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipline = new GithubPipeline
{
    Name = "Sheenam Build Pipline",
    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] {"main"}
        },

        Push = new PushEvent
        {
            Branches = new string[] {"main"}
        },

    },

    Jobs = new Dictionary<string, Job>
      {
          {
              "build",
              new Job
              {
                  RunsOn = BuildMachines.WindowsLatest,

                  Steps = new List<GithubTask>
                  {
                      new CheckoutTaskV2
                      {
                          Name = "Check out"
                      },

                      new SetupDotNetTaskV1
                      {
                          Name = "Setup .Net",

                          TargetDotNetVersion = new TargetDotNetVersion
                          {
                              DotNetVersion = "8.0.x",
                              IncludePrerelease = true
                          }
                      },

                      new RestoreTask
                      {
                          Name = "Restore"
                      },

                      new DotNetBuildTask
                      {
                          Name = "Build"
                      },

                      new TestTask
                      {
                          Name = "Test"
                      }
                  }
              }
          }
      }
};

var client = new ADotNetClient();


string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
string directoryPath = Path.GetDirectoryName(buildScriptPath)!;

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

client.SerializeAndWriteToFile
(
    adoPipeline: githubPipline,
    path: buildScriptPath
);