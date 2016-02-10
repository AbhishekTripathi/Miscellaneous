open System
open System.IO
open System.Collections
open System.Collections.Generic
open System.Linq
open System.Text.RegularExpressions
open Microsoft.FSharp.Data
open Microsoft.FSharp.Linq

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