Užduotis

Duotą JSON tekstą išsisaugokite į failą klientai.json:
[{"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 2","Address":"Liepų al. 3-1B,
Panevėžys","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 3","Address":"Varnių g. 39-9,
Kaunas","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 5","Address":"Švenčionių g. 36-2,
Nemenčinė, Vilniaus r. sav.","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
7","Address":"Vilniaus g. 220, Šiauliai","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
10","Address":"Baltų pr. 7A-1, Kaunas","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
9","Address":"Vytenio g. 16, Prienai","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
11","Address":"Livonijos g. 5, Joniškis","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
16","Address":"Šiltnamių g. 29, Vilnius","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
18","Address":"Kniaudiškių g. 6, Panevėžys","PostCode":""},{"Name":"UAB \"Gintarinė vaistinė\" fil. nr.
20","Address":"Nemuno g. 70, Panevėžys","PostCode":""}]

Sukurkite WEB aplikaciją su funkcijomis „Importuoti klientus“, „Atnaujinti pašto indeksus“, „Klientų
sąrašas“.
„Importuoti klientus“ - iš duoto JSON failo reikia į MSSQL duomenų bazę išsaugoti klientų sąrašą (vengti
duomenų sudubliavimo).
„Atnaujinti pašto indeksus“ - iš postit.lt puslapio pagal kliento adresą surasti pašto indeksą ir išsaugoti
duomenų bazėje.
Postit.lt užklausos pavyzdys:
https://api.postit.lt/?term=Savanorių+12,+Vilnius&key=postit.lt-examplekey
Naudojimo instrukcija adresu https://postit.lt/API/
„Klientų sąrašas“ – atidaro langą, kuriame rodome klientų sąrašą (iš duomenų bazės).
Duomenų bazėje padaryti log lentą, kurioje matytųsi atliktų veiksmų istorija – kada sukurtas kliento įrašas,
kada atnaujintas pašto indeksas ir t.t.
Prisijungimas prie duomenų bazės, postit užklausos adresas, postit key turi būti valdomi per konfigūraciją.
Darbo rezultatas – programos kodo failai ir duomenų bazės struktūros skriptas.
