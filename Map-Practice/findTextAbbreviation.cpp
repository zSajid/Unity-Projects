#include<iostream>
#include<map>
#include<string>
#include<fstream>

bool loadFile(std :: map<std::string, std::string>& myMap, std :: string fileName);

int main()
  {
    std :: map<std::string, std::string> myMap;

    loadFile(myMap, "LargestListofTextAbbreviations.txt");

   
    for(std :: map<std :: string, std :: string> :: iterator it = myMap.begin(); it != myMap.end(); ++it)
        {
          //std :: cout << "Acronym: " << it->first << " means: " << it->second << std :: endl;
         std :: cout  << it->first << " means: " << it->second << std :: endl;
       
        }


    std :: cout << "Please enter an acronym that you want to find for texting: ";
    std :: string uInString;
    std :: cin >> uInString;
    std :: cout << std :: endl;


    if(myMap.find(uInString) != myMap.end())
      {
        std :: cout << myMap.find(uInString)->second<< std :: endl;
      }



    return 0;
  }


bool loadFile(std :: map<std::string, std::string>& myMap, std :: string  fileName)
  {
    std :: ifstream fin(fileName.c_str());

    if(!fin)
      {
        std::cerr << "Problem loading file";
        return -1;
      }

    else
      {
        std :: string acronymTmp, valueTmp; 
        while(!fin.eof())
          {
            // Get the acronym
            fin >> acronymTmp ;
            std ::getline( fin, valueTmp);

            myMap.insert( std :: pair<std :: string , std :: string>(acronymTmp, valueTmp));

          } 

      }

  }