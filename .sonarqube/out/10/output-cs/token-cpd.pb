Š
VC:\Projects\anderson.souza\Ritter\tests\Application.Seedwork.Tests\Mocks\EntityTest.cs
	namespace 	
Ritter
 
. 
Application 
. 
Tests "
." #
Mocks# (
{ 
internal 
class 

EntityTest 
: 
Entity  &
{ 
public 

EntityTest 
( 
) 
: 
base 
( 
) 
{		 	
}

 	
public 

EntityTest 
( 
int 
id  
)  !
: 
base 
( 
) 
{ 	
Id 
= 
id 
; 
} 	
public 
void 
SetId 
( 
int 
id  
)  !
{ 	
Id 
= 
id 
; 
} 	
} 
} ™
ZC:\Projects\anderson.souza\Ritter\tests\Application.Seedwork.Tests\Mocks\ProjectionTest.cs
	namespace 	
Ritter
 
. 
Application 
. 
Tests "
." #
Mocks# (
{ 
internal 
class 
ProjectionTest !
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
} 
} Ž
eC:\Projects\anderson.souza\Ritter\tests\Application.Seedwork.Tests\Services\AppService_Constructor.cs
	namespace 	
Ritter
 
. 
Application 
. 
Tests "
." #
Services# +
{ 
public 

class "
AppService_Constructor '
{ 
[ 	
Fact	 
] 
public		 
void		 (
CreateAnInstanceOfAppService		 0
(		0 1
)		1 2
{

 	
var 

appService 
= 
new  
TestAppService! /
(/ 0
null0 4
)4 5
;5 6

appService 
. 
Should 
( 
) 
.  
	NotBeNull  )
() *
)* +
;+ ,
} 	
} 
} ƒ
]C:\Projects\anderson.souza\Ritter\tests\Application.Seedwork.Tests\Services\TestAppService.cs
	namespace 	
Ritter
 
. 
Application 
. 
Tests "
." #
Services# +
{ 
internal 
class 
TestAppService !
:" #

AppService$ .
{ 
public 
TestAppService 
( 
ILogger %
logger& ,
), -
:		 
base		 
(		 
logger		 
)		 
{

 	
} 	
} 
} 