open System
open System.IO
open System.Collections
open System.Collections.Generic
open System.Linq
open System.Text.RegularExpressions
open Microsoft.FSharp.Data
open Microsoft.FSharp.Linq

//Sample File Content Begins Below
//Sysinternals Utilities Index
//https://technet.microsoft.com/en-us/sysinternals/bb545027
//Sysinternals Suite
//The entire set of Sysinternals Utilities rolled up into a single download.
//==========================================================================
//AccessChk
//v6.01 (January 4, 2016)
//AccessChk is a command-line tool for viewing the effective permissions on files, registry keys, services, processes, kernel objects, and more.
//AccessEnum
//v1.32 (November 1, 2006)
//This simple yet powerful security tool shows you who has what access to directories, files and Registry keys on your systems. Use it to find holes in your permissions.
//AdExplorer

//#time
let fileContent = File.ReadAllLines(@"d:\dropbox\Tools\sysinternals\sysinternals_list.txt").Skip(5).ToArray()
type AppInfo = {Name:string; Version: string; ReleaseDate: string; Description: string}
let regexVersion = @"^(\S+)"
let regexDate = @"(?<=.+\().*[^\)]"
let parsedContent = 
    {0..3..fileContent.Count() - 1} 
    |> Seq.filter (fun x -> x % 3 = 0)
    |> Seq.map (fun counter -> 
        {   Name = fileContent.[counter]; 
            Version = Regex.Match(fileContent.[counter + 1], regexVersion).Value;
            ReleaseDate = Regex.Match(fileContent.[counter + 1], regexDate).Value;
            Description = fileContent.[counter + 2]
        })

printf "%A" parsedContent
