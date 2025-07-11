# HOW TO WORK WITH GIT ON WINDOWS
This is a brief resume in how to work to git and make your projects easier to manage, clone and go back behind when something get's wrong.

Visual Code and Visual Studio have diffetent ways to configure and linking gitHub, pay attention.

## Softwares needed:

- [**VISUAL STUDIO**](https://visualstudio.microsoft.com/)**/**[**VISUAL STUDIO CODE**](https://visualstudio.microsoft.com/) (optional)

-   [**GIT BASH**](https://git-scm.com/downloads)

- [**GitHub Desktop**](https://desktop.github.com/download/)



## Configuring GIT 
 In the git Bash execute this following commands

```bash
 - git config --global user.email "your@example.com"
 - git config --global user.name "Your Name"
```

## ADD AN LINKING REPOSITORY:

### Start the SSH SERVICE:
```bash
Start-Service ssh-agent
```
### Generate a key:
Open the Powershell / terminal  as adminitratos and execute the following command lines:

```bash
ssh-keygen -t ed25519 -C "your_email@example.com"
```
Accept an then proceed with enter.

-   Enter passphrase (empty for no passphrase): 
[Type a passphrase]
-   Enter same passphrase again: [Type passphrase again]

### Verify the creation of the ssh user by executing:
```bash 
ls ~/.ssh
```
### Verify connection by executing the following command:

```bash
ssh -T git@github.com
```



notice that it will creater 2 different keys, one public and one private.
```bash
~/.ssh/id_ed25519 (private key)
~/.ssh/id_ed25519.pub (public key)
```
### Copy the SSH key to the ClipBoard:
Pay attention, if you key has a different name of the example adjust the name so you don't have eventual problems in the configuration.

The following command needs to be runned in the terminal of the project in vscode on Windows. 

```bash
# Get Content - reads the text inside  SSH public key file and displays it in the terminal.

#Set-Clipboard Takes input and puts it on your system clipboard.

Get-Content ~/.ssh/id_ed25519.pub | Set-Clipboard
```
Get Content - reads the text inside  SSH public key file and displays it in the terminal.
### GitHub Configure SSh key:

Login in > Account > Settings > Access > SSH and GPG keys > New SSH key

copy the ssh key that has been generated into the box "key" present in the github webpage .

then we can proceed to add and link the repository.

### Note: 
It's needed to create a repository manually in github so que can proceed with the linking process.







## Creating a Folder:
 ```bash
 mkdir <NameOfTheFolder>
 cd <NameOfTheFolder>
 ```
### Open Visual code:
```bash
code .
```
## Git Commands:

```bash
#U - Unstaged 
#M - Modified
#A - Staged / Commited
```
## Stage Changes:
first stage changes than commit:

### Stage Files:

-   git init -> initialize the existance repository

-   git add `<filename>` -> state file change

-   git add . -> state alll changes

-   git add -a -> also state all changes


## Unstage/Restore files:

-   git restore `--staged` `<filename>` ->  unstages the file (removes it   from the staging area)

-   git restore `<filename>` -> restores the file, overwrite the last commit

## Commits:

### Commit:

- git commit -m "inital commit" -> commit the changes made in

### Undo Commit:

- git reset `--soft HEAD~1` -> undo last commit, keep changes

- git reset `HEAD~1` -> undo last commit and keep changes unstage 

- git reset `--hard HEAD~1` -> undo commit permanently and discard the changes

- git revert `<commit_hash>` -> Creates a new commit that reverses the changes from a previous one

### Find the commit hash:

-   git log --oneline

## Store the File Temporary:

- git stash -> save the working directory in an specific state

- git stash pop -> bring back the changes stored in the temporary file

## Creating and Switch Branches:

### Consult branch: `git branch`


- git branch `<branch-name>` -> create branch

- git checkout `<branch-name>` -> switches branch

- git checkout -b `<branch-name>` -> create and switch immediatly

- git switch -c `<branch-name>` -> create and Switch branch

### Merging and deleting Branches:


- git merge `<branch-name>` -> merges the branches

- git branch -d `<branch-name>` -> delete the branch if it is already merged

- git branch -D `<branch-name>` -> force the delete of the branch 

- git branch --delete --force `<branch-name>`

## Deleting Files:

-   git rm `<filename>` -> delete from 

-   git rm --cached `<filename>` -> delete from git and keep locally

## Git PUSH

### Create a new repository on the command line

```bash
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin git@github.com:orlandonss/test.git
git push -u origin main
```
### Push an existing repository from the command line

```bash
git remote add origin git@github.com:orlandonss/test.git
git branch -M main
git push -u origin main
```

## THE GIT REMOTE:

Command :  `git remote -v`

Lists the remote repositories connected to your local Git project.

Shows both fetch and push URLs. 
-   Output Example:

```bash
origin  https://github.com/yourname/your-repo.git (fetch)
origin  https://github.com/yourname/your-repo.git (push)
```

origin is the default name for the remote repo (you can have more than one).

-   The (fetch) URL is used when pulling.

-   The (push) URL is used when pushing.
