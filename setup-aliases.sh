#!/bin/bash

FSHARP_PATH="./fsharp"

# Create or append to the .bashrc or .zshrc file
if [ -n "$BASH_VERSION" ]; then
    # For bash users
    echo "alias fslex=\"dotnet $FSHARP_PATH/fslex.dll\"" >> ~/.bashrc
    echo "alias fsyacc=\"dotnet $FSHARP_PATH/fsyacc.dll\"" >> ~/.bashrc
    echo "Aliases added to ~/.bashrc. Please run 'source ~/.bashrc' to apply changes."
elif [ -n "$ZSH_VERSION" ]; then
    # For zsh users
    echo "alias fslex=\"dotnet $FSHARP_PATH/fslex.dll\"" >> ~/.zshrc
    echo "alias fsyacc=\"dotnet $FSHARP_PATH/fsyacc.dll\"" >> ~/.zshrc
    echo "Aliases added to ~/.zshrc. Please run 'source ~/.zshrc' to apply changes."
else
    echo "Unsupported shell. Please manually add the aliases."
fi

### Summary
#setup script in your  to make it easier for everyone who clones the repository to 
#set up their environment consistently. 
#The script will modify the `.bashrc` or `.zshrc` files 
#to include the necessary aliases, which can then be applied by 
#sourcing the appropriate configuration file.
