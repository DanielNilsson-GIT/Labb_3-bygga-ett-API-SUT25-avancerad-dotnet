//Hämta alla personer i systemet:
/api/Person
[
  {
    "name": "Anna Svensson",
    "phone": 111111
  },
  {
    "name": "Björn Karlsson",
    "phone": 222222
  },
  {
    "name": "Cecilia Lind",
    "phone": 333333
  },
  {
    "name": "David Persson",
    "phone": 444444
  },
  {
    "name": "Elin Johansson",
    "phone": 555555
  },
  {
    "name": "Filip Berg",
    "phone": 666666
  },
  {
    "name": "Greta Holm",
    "phone": 777777
  },
  {
    "name": "Hugo Sand",
    "phone": 888888
  },
  {
    "name": "Ida Ek",
    "phone": 999999
  },
  {
    "name": "Johan Ström",
    "phone": 101010
  }
]

//Hämta alla intressen kopplade till en specifik person
/api/Person/GetInterestsByPersonId/{id}

{
  "personId": 4,
  "personName": "David Persson",
  "interests": [
    "Gaming"
  ]
}

//Hämta alla länkar kopplade till en specifik person
/api/Person/GetLinksByPersonId/{id}
{
  "personId": 4,
  "personName": "David Persson",
  "websites": [
    "https://ign.com"
  ]
}

//Koppla en person till ett nytt intresse
/api/Person/AddNewInterest/Person{id}
requestbody: {
  "title": "string",
  "descripiton": "string"
}
response body:
{
  "title": "Surfiing",
  "descripiton": "Riding the waves!"
}

//Lägga till nya länkar för en specifik person och ett specifikt intresse
/api/Person/AddNewLink/{PersonId}/{InterestId}
RequestBody: {
  "personId": 0,
  "interestId": 0,
  "websiteURL": "string"
}

REsponseBody: 
{
  "id": 24,
  "websiteURL": "www.NewLinkAddedTest",
  "personId": 4,
  "interestId": 2
}

