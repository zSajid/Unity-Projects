#include<map>
#include<iostream>
using namespace std;


int main(int argc, const char **argv)
	{
		// Key type value pointer type
		map<char, char *> MyMap;

		// One element in myMap that has key of 0 and value of "charley"
		MyMap['a'] = "Alex";
		MyMap['b'] = "Bob";
		MyMap['c'] = "Charley";
		MyMap['d'] = "Cristian";
		MyMap['e'] = "Karta";
		MyMap['f'] = "Richard";

		cout << "MyMap Size = " << MyMap.size() << endl;

		// Iterator 
		for(map<char, char*> :: const_iterator it = MyMap.begin(); it != MyMap.end(); ++it)
			{
				// First is the key, the value is second
				cout << "MyMap [" << it->first << "] = " << it->second << endl;

			}
		char uIn;
		cout << "Please enter a letter: ";
		cin >> uIn; 
		cout << endl;

		// This is a iterator, to find the value
		if(MyMap.find(uIn) != MyMap.end())
			{
			cout << MyMap.find(uIn) ->second << endl;
			}
		return 0;

	}