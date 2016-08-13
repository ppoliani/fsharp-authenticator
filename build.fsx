// include Fake libs

#r "fsharp-authenticator/packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing
open System
open System.IO

// Directories
let buildDir  = "./build/"
let deployDir = "./deploy/"
let testDir = "./fsharp-authenticator-tests/bin/Debug/"


// Filesets
let appReferences  =
    !! "/**/*.csproj"
    ++ "/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; deployDir]
)

Target "Build" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)

Target "Deploy" (fun _ ->
    !! (buildDir + "/**/*.*")
    -- "*.zip"
    |> Zip buildDir (deployDir + "ApplicationName." + version + ".zip")
)

let testReferences = !! (testDir + "**/*.fsproj")

Target "BuildTest" (fun _ ->
    MSBuildDebug testDir "Build" testReferences
        |> Log "TestBuild-Output: "
)

Target "xUnitTest" (fun _ ->
    trace "Running Tests..."
    !! ("build/*tests.dll")
         |> xUnit2 (fun p -> {
                             p with HtmlOutputPath = Some(testDir @@ "xunit.html")
                                    ToolPath =  @"fsharp-authenticator-tests/packages/xunit.runner.console/tools/xunit.console.exe"})
)

// Build order
"Clean"
  ==> "Build"
  ==> "BuildTest"
  ==> "xUnitTest"
  ==> "Deploy"

// start build
RunTargetOrDefault "Build"
