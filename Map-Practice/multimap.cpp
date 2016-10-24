#include<map>
#include<iostream>
#include<fstream>
using namespace std;

bool loadFile(multimap<string, string>& myMap, string fileName);

int main()
    {
    	multimap<string, string> listOfFamousAcronyms;

    	if(!loadFile(listOfFamousAcronyms, "abbreviation.txt"))
	    	{
				cerr << ("Bad File Input");	    		
	    	}
                       
      // A user input acronym      
	    string uInAcronym;

      // Ask for input
      cout << "Enter a acronym all captials : ";
      cin >> uInAcronym;;

      cout << endl << endl;

      pair<multimap<string, string> :: iterator, multimap<string, string> ::iterator> pairOfIterators;

      pairOfIterators = listOfFamousAcronyms.equal_range(uInAcronym);

      multimap<string, string>:: iterator it;

      for(it = pairOfIterators.first; it != pairOfIterators.second; ++it){
        cout << it->first << " = " << it->second << endl;

      }

      return 0;
    }


bool loadFile(multimap<string, string>& myMap, string fileName)
    {
        // Create fin variable with the name of the file
        ifstream fin(fileName.c_str()); 

        if(!fin)
            {
                return false;
            }

        else
            {
            	// Essentially the key and the value of that key
                string acronym, stands_for;

                // This is to store in the dash mark from the abbreviation
                char junk;

                while(!fin.eof()){
                	fin >> acronym;
                	fin >> junk;
                	fin >> stands_for;

                	myMap.insert(pair<string, string>(acronym, stands_for));
                }
                fin.close();
            }
      return true;

    }