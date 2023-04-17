
# Swift standards MT Convert Tool

A C# script that transforms a .txt file from MT format to the required .txt format using specific instructions for building the message according to FFS (Financial Information eXchange (FIX) for Foreign Exchange). These instructions involve removing the commas at the beginning of each field, completing the tag information in the same line after the colon, and respecting the format of each tag according to SWIFT standards. The resulting content is stored in two different folders: the OneLine folder contains the file in a single-line format, while the Salida folder contains the file in the required format with certain conditions.


## Usage/Examples
To convert MT messages to the required format, you can follow these steps:

1.Go to Swift Standard MT.

2.Navigate to the selected category (e.g. Category 7).

3.Go to the Message Reference.

4.Search for the MT format specification.

5.Copy and paste the table into Excel.

6.Copy and paste from Excel into a text file (.txt).

7.Save the MT.txt file into the Input folder.




Example MT 700 Issue of a Documentary Credit.txt MT Input
```
M	27	Sequence of Total	1!n/1!n	1
M	40A	Form of Documentary Credit	24x	2
M	20	Documentary Credit Number	16x	3
O	23	Reference to Pre-Advice	16x	4
M	31C	Date of Issue	6!n	5
M	40E	Applicable Rules	30x[/35x]	6
M	31D	Date and Place of Expiry	6!n29x	7
O	51a	Applicant Bank	A or D	8
M	50	Applicant	4*35x	9
M	59	Beneficiary	[/34x]<crlf>4*35x	10
M	32B	Currency Code, Amount	3!a15d	11
O	39A	Percentage Credit Amount Tolerance	2n/2n	12
O	39C	Additional Amounts Covered	4*35x	13
M	41a	Available With ... By ...	A or D	14
O	42C	Drafts at ...	3*35x	15
O	42a	Drawee	A or D	16
O	42M	Mixed Payment Details	4*35x	17
O	42P	Negotiation/Deferred Payment Details	4*35x	18
O	43P	Partial Shipments	11x	19
O	43T	Transhipment	11x	20
O	44A	Place of Taking in Charge/Dispatch from .../Place of Receipt	65x	21
O	44E	Port of Loading/Airport of Departure	65x	22
O	44F	Port of Discharge/Airport of Destination	65x	23
O	44B	Place of Final Destination/For Transportation to .../Place of Delivery	65x	24
O	44C	Latest Date of Shipment	6!n	25
O	44D	Shipment Period	6*65x	26
O	45A	Description of Goods and/or Services	100*65z	27
O	46A	Documents Required	100*65z	28
O	47A	Additional Conditions	100*65z	29
O	49G	Special Payment Conditions for Beneficiary	100*65z	30
O	49H	Special Payment Conditions for Bank Only	100*65z	31
O	71D	Charges	6*35z	32
O	48	Period for Presentation in Days	3n[/35x]	33
M	49	Confirmation Instructions	7!x	34
O	58a	Requested Confirmation Party	A or D	35
O	53a	Reimbursing Bank	A or D	36
O	78	Instructions to the Paying/Accepting/Negotiating Bank	12*65x	37
O	57a	'Advise Through' Bank	A, B, or D	38
O	72Z	Sender to Receiver Information	6*35z	39

```

Example MT 700 Issue of a Documentary Credit_Modify.txt FFS Output in Salida Folder
```
,,MT 700 Issue of a Documentary Credit                           
,,:TAG27: Sequence of Total(M)(1!n/1!n)                          
,:27:                                                            
,,:TAG40A: Form of Documentary Credit(M)(24x)                    
,:40A:                                                           
,,:TAG20: Documentary Credit Number(M)(16x)                      
,:20:                                                            
,,:TAG23: Reference to Pre-Advice(O)(16x)                        
,:23:                                                            
,,:TAG31C: Date of Issue(M)(6!n)                                 
,:31C:                                                           
,,:TAG40E: Applicable Rules(M)(30x[/35x])                        
,:40E:                                                           
,,:TAG31D: Date and Place of Expiry(M)(6!n29x)                   
,:31D:                                                           
,,:TAG51a: Applicant Bank(O)(A or D)                             
,:51a:                                                           
,,:TAG50: Applicant(M)(4*35x)                                    
,:50:                                                            
,,:TAG59: Beneficiary(M)([/34x]<crlf>4*35x)                      
,:59:                                                            
,,:TAG32B: Currency Code, Amount(M)(3!a15d)                      
,:32B:                                                           
,,:TAG39A: Percentage Credit Amount Tolerance(O)(2n/2n)          
,:39A:                                                           
,,:TAG39C: Additional Amounts Covered(O)(4*35x)                  
,:39C:                                                           
,,:TAG41a: Available With ... By ...(M)(A or D)                  
,:41a:                                                           
,,:TAG42C: Drafts at ...(O)(3*35x)                               
,:42C:                                                           
,,:TAG42a: Drawee(O)(A or D)                                     
,:42a:                                                           
,,:TAG42M: Mixed Payment Details(O)(4*35x)                       
,:42M:                                                           
,,:TAG42P: Negotiation/Deferred Payment Details(O)(4*35x)        
,:42P:                                                           
,,:TAG43P: Partial Shipments(O)(11x)                             
,:43P:                                                           
,,:TAG43T: Transhipment(O)(11x)                                  
,:43T:                                                           
,,:TAG44A: Place of Taking in Charge/Dispatch from .../Place of R
,,ceipt(O)(65x)                                                  
,:44A:                                                           
,,:TAG44E: Port of Loading/Airport of Departure(O)(65x)          
,:44E:                                                           
,,:TAG44F: Port of Discharge/Airport of Destination(O)(65x)      
,:44F:                                                           
,,:TAG44B: Place of Final Destination/For Transportation to .../P
,,ace of Delivery(O)(65x)                                        
,:44B:                                                           
,,:TAG44C: Latest Date of Shipment(O)(6!n)                       
,:44C:                                                           
,,:TAG44D: Shipment Period(O)(6*65x)                             
,:44D:                                                           
,,:TAG45A: Description of Goods and/or Services(O)(100*65z)      
,:45A:                                                           
,,:TAG46A: Documents Required(O)(100*65z)                        
,:46A:                                                           
,,:TAG47A: Additional Conditions(O)(100*65z)                     
,:47A:                                                           
,,:TAG49G: Special Payment Conditions for Beneficiary(O)(100*65z)
,:49G:                                                           
,,:TAG49H: Special Payment Conditions for Bank Only(O)(100*65z)  
,:49H:                                                           
,,:TAG71D: Charges(O)(6*35z)                                     
,:71D:                                                           
,,:TAG48: Period for Presentation in Days(O)(3n[/35x])           
,:48:                                                            
,,:TAG49: Confirmation Instructions(M)(7!x)                      
,:49:                                                            
,,:TAG58a: Requested Confirmation Party(O)(A or D)               
,:58a:                                                           
,,:TAG53a: Reimbursing Bank(O)(A or D)                           
,:53a:                                                           
,,:TAG78: Instructions to the Paying/Accepting/Negotiating Bank(O
,,(12*65x)                                                       
,:78:                                                            
,,:TAG57a: 'Advise Through' Bank(O)(A, B, or D)                  
,:57a:                                                           
,,:TAG72Z: Sender to Receiver Information(O)(6*35z)              
,:72Z:                           
```

Example MT 700 Issue of a Documentary Credit_OneLine.txt FFS in Single Line Output in OneLine Folder
```
,,MT 700 Issue of a Documentary Credit                           ,,                COMO SE ARMA EL MT POR FFS                     ,,SE DEBEN ELIMINAR LAS COMAS QUE FIGURAN AL PRINCIPIO DE CADA   ,,CAMPO DESTINADO A LA GENERACION DE LOS TAGS EJEMPLO:           ,,:SRI: O :20: Y COMPLETAR EN LA MISMA LINEA LUEGO DE LOS DOS    ,,PUNTOS CON LA INFORMACION NECESARIA RESPETANDO EL FORMATO DE   ,,CADA TAG SEGUN LO INDICA SWIFT. EJEMPLO :20:BKTD-I002137000    ,,SI DEBEN ESCRIBIR MAS DE UNA LINEA, ESCIBIR DEBAJO DEL TAG     ,,CORRESPONDIENTE, UNA LINEA DEBAJO DE LA OTRA RESPETANDO LA     ,,CANTIDAD DE CARACTERES DEL TAG Y NO DEBE EMPEZAR CON COMAS     ,,EN EL CAMPO :SRI: DEBE IR LA DIRECCION BIC DEL BANCO DE        ,,DESTINATARIO DEL MENSAJE.                                      ,,:TAG27: Sequence of Total(M)(1!n/1!n)                          ,:27:                                                            ,,:TAG40A: Form of Documentary Credit(M)(24x)                    ,:40A:                                                           ,,:TAG20: Documentary Credit Number(M)(16x)                      ,:20:                                                            ,,:TAG23: Reference to Pre-Advice(O)(16x)                        ,:23:                                                            ,,:TAG31C: Date of Issue(M)(6!n)                                 ,:31C:                                                           ,,:TAG40E: Applicable Rules(M)(30x[/35x])                        ,:40E:                                                           ,,:TAG31D: Date and Place of Expiry(M)(6!n29x)                   ,:31D:                                                           ,,:TAG51a: Applicant Bank(O)(A or D)                             ,:51a:                                                           ,,:TAG50: Applicant(M)(4*35x)                                    ,:50:                                                            ,,:TAG59: Beneficiary(M)([/34x]<crlf>4*35x)                      ,:59:                                                            ,,:TAG32B: Currency Code, Amount(M)(3!a15d)                      ,:32B:                                                           ,,:TAG39A: Percentage Credit Amount Tolerance(O)(2n/2n)          ,:39A:                                                           ,,:TAG39C: Additional Amounts Covered(O)(4*35x)                  ,:39C:                                                           ,,:TAG41a: Available With ... By ...(M)(A or D)                  ,:41a:                                                           ,,:TAG42C: Drafts at ...(O)(3*35x)                               ,:42C:                                                           ,,:TAG42a: Drawee(O)(A or D)                                     ,:42a:                                                           ,,:TAG42M: Mixed Payment Details(O)(4*35x)                       ,:42M:                                                           ,,:TAG42P: Negotiation/Deferred Payment Details(O)(4*35x)        ,:42P:                                                           ,,:TAG43P: Partial Shipments(O)(11x)                             ,:43P:                                                           ,,:TAG43T: Transhipment(O)(11x)                                  ,:43T:                                                           ,,:TAG44A: Place of Taking in Charge/Dispatch from .../Place of R,,ceipt(O)(65x)                                                  ,:44A:                                                           ,,:TAG44E: Port of Loading/Airport of Departure(O)(65x)          ,:44E:                                                           ,,:TAG44F: Port of Discharge/Airport of Destination(O)(65x)      ,:44F:                                                           ,,:TAG44B: Place of Final Destination/For Transportation to .../P,,ace of Delivery(O)(65x)                                        ,:44B:                                                           ,,:TAG44C: Latest Date of Shipment(O)(6!n)                       ,:44C:                                                           ,,:TAG44D: Shipment Period(O)(6*65x)                             ,:44D:                                                           ,,:TAG45A: Description of Goods and/or Services(O)(100*65z)      ,:45A:                                                           ,,:TAG46A: Documents Required(O)(100*65z)                        ,:46A:                                                           ,,:TAG47A: Additional Conditions(O)(100*65z)                     ,:47A:                                                           ,,:TAG49G: Special Payment Conditions for Beneficiary(O)(100*65z),:49G:                                                           ,,:TAG49H: Special Payment Conditions for Bank Only(O)(100*65z)  ,:49H:                                                           ,,:TAG71D: Charges(O)(6*35z)                                     ,:71D:                                                           ,,:TAG48: Period for Presentation in Days(O)(3n[/35x])           ,:48:                                                            ,,:TAG49: Confirmation Instructions(M)(7!x)                      ,:49:                                                            ,,:TAG58a: Requested Confirmation Party(O)(A or D)               ,:58a:                                                           ,,:TAG53a: Reimbursing Bank(O)(A or D)                           ,:53a:                                                           ,,:TAG78: Instructions to the Paying/Accepting/Negotiating Bank(O,,(12*65x)                                                       ,:78:                                                            ,,:TAG57a: 'Advise Through' Bank(O)(A, B, or D)                  ,:57a:                                                           ,,:TAG72Z: Sender to Receiver Information(O)(6*35z)              ,:72Z:                                                           
```
## Authors
Alexander Kibysz
- [@AlexKibysz](https://github.com/AlexKibysz)

