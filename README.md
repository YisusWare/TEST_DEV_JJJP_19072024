# TEST_DEV_JJJP_19072024

This project was building with .NET 5 and Angular 16,
here is a guide for its correct setup.

# Setup Angular application

The first and the foremost, you need to clone the repository and after that install node.js 18 or higher. Node can be downloaded from the official website, the best option is to download the long term support version (18.20.4)

`https://nodejs.org/en/download/prebuilt-installer`

Download the installation wizard and follow the instructions, after that type the following command on the CMD 
`node --version`
you must get a message like this

`v18.20.4`

##Install Angular (16)

Now we are able to install Angular, the following command will install angular 16 wich is the version tthat i'm using in this project

`npm install -g @angular/cli@16`

However if you just want to install the most recent Angular version just run the following command
`npm install -g @angular/cli`

Then you can check if the install was successfull by running
`ng version`

That must show you the following message


    @angular-devkit/architect       0.1602.14
    @angular-devkit/build-angular   16.2.14
    @angular-devkit/core            16.2.14
    @angular-devkit/schematics      16.2.14
    @angular/cli                    16.2.14
    @schematics/angular             16.2.14
    rxjs                            7.8.1
    typescript                      5.1.6
    zone.js                         0.13.3`
With both Node and Angular installed, go to the root folder of the angular project (FRONT\TEST_DEV_FRONT) and run the following command to install all the needed dependencies 
`npm install --legacy-per-deps`

Run the project by running 
`ng serve -o`

#.NET Project
the configuration of the web API is much easyer, just need to install VisualStudio 2019 and .NET 5

#Common problems
the port when the API runs coud change from one computer to another, this could be a problem because the frontend will never connect, in order to solve this problem run the web API and check for the port where it is running. Then on the angular project, look for the **environment.ts** file and change the port number, for example, if the web API is running on the **44303** port your file must look like this.



    export const environment = {
        production: false,
        apiUrl:  'https://localhost:44303/api/'
    }