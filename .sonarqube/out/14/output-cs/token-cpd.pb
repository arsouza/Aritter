´1
_C:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Web\Controllers\EmployeesController.cs
	namespace

 	
Ritter


 
.

 
Samples

 
.

 
Web

 
.

 
Controllers

 (
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
EmployeesController $
:% &
ApiController' 4
{ 
private 
readonly 
IEmployeeAppService ,
employeeAppService- ?
;? @
public 
EmployeesController "
(" #
IEmployeeAppService# 6
employeeAppService7 I
)I J
{ 	
this 
. 
employeeAppService #
=$ %
employeeAppService& 8
;8 9
} 	
[%% 	
HttpGet%%	 
]%% 
[&& 	 
ProducesResponseType&&	 
(&& 
typeof&& $
(&&$ %
PagedResult&&% 0
<&&0 1
GetEmployeeDto&&1 ?
>&&? @
)&&@ A
,&&A B
(&&C D
int&&D G
)&&G H
HttpStatusCode&&H V
.&&V W
OK&&W Y
)&&Y Z
]&&Z [
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' (
Get'') ,
('', -
PagingFilter''- 9

pageFilter'': D
)''D E
=>''F H
Ok''I K
(''K L
await''L Q
employeeAppService''R d
.''d e
ListEmployees''e r
(''r s

pageFilter''s }
)''} ~
)''~ 
;	'' Ä
[66 	
HttpGet66	 
]66 
[77 	
Route77	 
(77 
$str77 !
,77! "
Name77# '
=77( )
$str77* 7
)777 8
]778 9
[88 	 
ProducesResponseType88	 
(88 
typeof88 $
(88$ %
GetEmployeeDto88% 3
)883 4
,884 5
(886 7
int887 :
)88: ;
HttpStatusCode88; I
.88I J
OK88J L
)88L M
]88M N
[99 	 
ProducesResponseType99	 
(99 
(99 
int99 "
)99" #
HttpStatusCode99# 1
.991 2
NotFound992 :
)99: ;
]99; <
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
Get::) ,
(::, -
int::- 0

employeeId::1 ;
)::; <
=>::= ?
OkOrNotFound::@ L
(::L M
await::M R
employeeAppService::S e
.::e f
GetEmployee::f q
(::q r

employeeId::r |
)::| }
)::} ~
;::~ 
[NN 	
HttpPostNN	 
]NN 
[OO 	 
ProducesResponseTypeOO	 
(OO 
typeofOO $
(OO$ %
GetEmployeeDtoOO% 3
)OO3 4
,OO4 5
(OO6 7
intOO7 :
)OO: ;
HttpStatusCodeOO; I
.OOI J
CreatedOOJ Q
)OOQ R
]OOR S
[PP 	 
ProducesResponseTypePP	 
(PP 
(PP 
intPP "
)PP" #
HttpStatusCodePP# 1
.PP1 2

BadRequestPP2 <
)PP< =
]PP= >
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ '
>QQ' (
PostQQ) -
(QQ- .
[QQ. /
FromBodyQQ/ 7
]QQ7 8
AddEmployeeDtoQQ9 G
employeeDtoQQH S
)QQS T
{RR 	
varSS 
employeeSS 
=SS 
awaitSS  
employeeAppServiceSS! 3
.SS3 4
AddEmployeeSS4 ?
(SS? @
employeeDtoSS@ K
)SSK L
;SSL M
returnTT 
CreatedAtRouteTT !
(TT! "
	routeNameUU 
:UU 
$strUU (
,UU( )
routeValuesVV 
:VV 
newVV  
{VV! "

employeeIdVV# -
=VV. /
employeeVV0 8
.VV8 9

EmployeeIdVV9 C
}VVD E
,VVE F
valueWW 
:WW 
employeeWW 
)WW  
;WW  !
}XX 	
[nn 	
	HttpPatchnn	 
]nn 
[oo 	
Routeoo	 
(oo 
$stroo !
)oo! "
]oo" #
[pp 	 
ProducesResponseTypepp	 
(pp 
typeofpp $
(pp$ %
GetEmployeeDtopp% 3
)pp3 4
,pp4 5
(pp6 7
intpp7 :
)pp: ;
HttpStatusCodepp; I
.ppI J
AcceptedppJ R
)ppR S
]ppS T
[qq 	 
ProducesResponseTypeqq	 
(qq 
(qq 
intqq "
)qq" #
HttpStatusCodeqq# 1
.qq1 2
NotFoundqq2 :
)qq: ;
]qq; <
[rr 	 
ProducesResponseTyperr	 
(rr 
(rr 
intrr "
)rr" #
HttpStatusCoderr# 1
.rr1 2

BadRequestrr2 <
)rr< =
]rr= >
publicss 
asyncss 
Taskss 
<ss 
IActionResultss '
>ss' (
Patchss) .
(ss. /
intss/ 2

employeeIdss3 =
,ss= >
[ss? @
FromBodyss@ H
]ssH I
UpdateEmployeeDtossJ [
employeeDtoss\ g
)ssg h
{tt 	
varuu 
employeeuu 
=uu 
awaituu  
employeeAppServiceuu! 3
.uu3 4
UpdateEmployeeuu4 B
(uuB C

employeeIduuC M
,uuM N
employeeDtouuO Z
)uuZ [
;uu[ \
returnvv 
AcceptedAtRoutevv "
(vv" #
	routeNameww 
:ww 
$strww (
,ww( )
routeValuesxx 
:xx 
newxx  
{xx! "

employeeIdxx# -
=xx. /
employeexx0 8
.xx8 9

EmployeeIdxx9 C
}xxD E
,xxE F
valueyy 
:yy 
employeeyy 
)yy  
;yy  !
}zz 	
}{{ 
}|| ∂
GC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Web\Program.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Web 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
WebHost

 
.

  
CreateDefaultBuilder

 (
(

( )
args

) -
)

- .
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
. 

UseKestrel 
( 
) 
. 
Build 
( 
) 
. 
Run 
( 
) 
; 
} 	
} 
} ¯'
GC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Web\Startup.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Web 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddDependencies $
($ %
Configuration% 2
.2 3
GetConnectionString3 F
(F G
$strG Z
)Z [
)[ \
;\ ]
services 
. 
AddTypeAdapter #
<# $!
AutoMapperTypeAdapter$ 9
>9 :
(: ;
); <
;< =
services 
.   
AddMvc   
(   
s   
=>   
{!! 
s"" 
."" 
Filters"" 
."" 
Add"" !
(""! "
new""" %$
HttpErrorFilterAttribute""& >
(""> ?
)""? @
)""@ A
;""A B
}## 
)## 
.$$ 
AddJsonOptions$$ 
($$  
options$$  '
=>$$( *
{%% 
options&& 
.&& 
SerializerSettings&& .
.&&. /
ContractResolver&&/ ?
=&&@ A
new&&B E2
&CamelCasePropertyNamesContractResolver&&F l
(&&l m
)&&m n
;&&n o
options'' 
.'' 
SerializerSettings'' .
.''. /

Formatting''/ 9
='': ;

Formatting''< F
.''F G
Indented''G O
;''O P
}(( 
)(( 
;(( 
services** 
.** 
AddSwaggerGen** "
(**" #
c**# $
=>**% '
{++ 
c,, 
.,, 

SwaggerDoc,, 
(,, 
$str,, !
,,,! "
new,,# &
Info,,' +
{,,, -
Title,,. 3
=,,4 5
$str,,6 I
,,,I J
Version,,K R
=,,S T
$str,,U Y
},,Z [
),,[ \
;,,\ ]
c-- 
.-- 
IncludeXmlComments-- $
(--$ %
GetXmlComments--% 3
(--3 4
)--4 5
)--5 6
;--6 7
c.. 
... 
DocumentFilter..  
<..  !#
LowercaseDocumentFilter..! 8
>..8 9
(..9 :
)..: ;
;..; <
c// 
.// ,
 DescribeAllParametersInCamelCase// 2
(//2 3
)//3 4
;//4 5
}00 
)00 
;00 
}11 	
public33 
void33 
	Configure33 
(33 
IApplicationBuilder33 1
app332 5
,335 6
IHostingEnvironment337 J
env33K N
)33N O
{44 	
if55 
(55 
env55 
.55 
IsDevelopment55 !
(55! "
)55" #
)55# $
app66 
.66 %
UseDeveloperExceptionPage66 -
(66- .
)66. /
;66/ 0
app88 
.88 

UseSwagger88 
(88 
)88 
;88 
app:: 
.:: 
UseSwaggerUI:: 
(:: 
c:: 
=>:: !
{;; 
c<< 
.<< 
SwaggerEndpoint<< !
(<<! "
$str<<" <
,<<< =
$str<<> T
)<<T U
;<<U V
c== 
.== 
RoutePrefix== 
=== 
string==  &
.==& '
Empty==' ,
;==, -
}>> 
)>> 
;>> 
app@@ 
.@@ 
UseMvc@@ 
(@@ 
)@@ 
;@@ 
}AA 	
privateCC 
staticCC 
stringCC 
GetXmlCommentsCC ,
(CC, -
)CC- .
{DD 	
varEE 
xmlFileEE 
=EE 
$"EE 
{EE 
AssemblyEE %
.EE% &
GetEntryAssemblyEE& 6
(EE6 7
)EE7 8
.EE8 9
GetNameEE9 @
(EE@ A
)EEA B
.EEB C
NameEEC G
}EEG H
.xmlEEH L
"EEL M
;EEM N
varFF 
xmlPathFF 
=FF 
PathFF 
.FF 
CombineFF &
(FF& '

AppContextFF' 1
.FF1 2
BaseDirectoryFF2 ?
,FF? @
xmlFileFFA H
)FFH I
;FFI J
returnGG 
xmlPathGG 
;GG 
}HH 	
}II 
}JJ æ
fC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Web\SwaggerFilters\LowercaseDocumentFilter.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Web 
. 
SwaggerFilters +
{ 
public 

class #
LowercaseDocumentFilter (
:) *
IDocumentFilter+ :
{		 
public

 
void

 
Apply

 
(

 
SwaggerDocument

 )

swaggerDoc

* 4
,

4 5!
DocumentFilterContext

6 K
context

L S
)

S T
{ 	
var 
paths 
= 

swaggerDoc "
." #
Paths# (
;( )
var 
newPaths 
= 
new 

Dictionary )
<) *
string* 0
,0 1
PathItem2 :
>: ;
(; <
)< =
;= >
var 

removeKeys 
= 
new  
List! %
<% &
string& ,
>, -
(- .
). /
;/ 0
foreach 
( 
var 
path 
in  
paths! &
)& '
{ 
var 
newKey 
= ,
 LowercaseEverythingButParameters =
(= >
path> B
.B C
KeyC F
)F G
;G H
if 
( 
newKey 
!= 
path "
." #
Key# &
)& '
{ 

removeKeys 
. 
Add "
(" #
path# '
.' (
Key( +
)+ ,
;, -
newPaths 
. 
Add  
(  !
newKey! '
,' (
path) -
.- .
Value. 3
)3 4
;4 5
} 
} 
foreach 
( 
var 
path 
in  
newPaths! )
)) *
{ 

swaggerDoc   
.   
Paths    
.    !
Add  ! $
(  $ %
path  % )
.  ) *
Key  * -
,  - .
path  / 3
.  3 4
Value  4 9
)  9 :
;  : ;
}!! 
foreach$$ 
($$ 
var$$ 
key$$ 
in$$ 

removeKeys$$  *
)$$* +
{%% 

swaggerDoc&& 
.&& 
Paths&&  
.&&  !
Remove&&! '
(&&' (
key&&( +
)&&+ ,
;&&, -
}'' 
}(( 	
private** 
string** ,
 LowercaseEverythingButParameters** 7
(**7 8
string**8 >
key**? B
)**B C
=>**C E
string**F L
.**L M
Join**M Q
(**Q R
$char**R U
,**U V
key**W Z
.**Z [
Split**[ `
(**` a
$char**a d
)**d e
.**e f
Select**f l
(**l m
x**m n
=>**o q
x**r s
.**s t
Contains**t |
(**| }
$str	**} Ä
)
**Ä Å
?
**Ç É
x
**Ñ Ö
:
**Ü á
x
**à â
.
**â ä
ToLower
**ä ë
(
**ë í
)
**í ì
)
**ì î
)
**î ï
;
**ï ñ
}++ 
},, 