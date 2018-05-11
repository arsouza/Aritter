»G
mC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Application\Services\Employees\EmployeeAppService.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Application $
.$ %
Services% -
.- .
	Employees. 7
{ 
public 

class 
EmployeeAppService #
:$ %

AppService& 0
,0 1
IEmployeeAppService2 E
{ 
private 
readonly 
ITypeAdapter %
typeAdapter& 1
;1 2
private 
readonly 
IEmployeeRepository ,
employeeRepository- ?
;? @
public 
EmployeeAppService !
(! "
ITypeAdapter 
typeAdapter $
,$ %
IEmployeeRepository 
employeeRepository  2
)2 3
: 
base 
( 
null 
) 
{ 	
this 
. 
typeAdapter 
= 
typeAdapter *
;* +
this 
. 
employeeRepository #
=$ %
employeeRepository& 8
;8 9
} 	
public 
async 
Task 
< 
GetEmployeeDto (
>( )
AddEmployee* 5
(5 6
AddEmployeeDto6 D
employeeDtoE P
)P Q
{   	
var!! 
	validator!! 
=!! 
new!! 
EmployeeValidator!!  1
(!!1 2
)!!2 3
;!!3 4
var## 
employee## 
=## 
new## 
Employee## '
(##' (
employeeDto##( 3
.##3 4
	FirstName##4 =
,##= >
employeeDto##? J
.##J K
LastName##K S
,##S T
employeeDto##U `
.##` a
Cpf##a d
)##d e
;##e f
	validator%% 
.%% 
Validate%% 
(%% 
employee%% '
)%%' (
.%%( )
EnsureValid%%) 4
(%%4 5
)%%5 6
;%%6 7
var'' 
employeeExists'' 
=''  
await''! &
employeeRepository''' 9
.''9 :
AnyAsync'': B
(''B C
new''C F
DirectSpecification''G Z
<''Z [
Employee''[ c
>''c d
(''d e
e''e f
=>''g i
e''j k
.''k l
Cpf''l o
==''p r
employee''s {
.''{ |
Cpf''| 
)	'' Ä
)
''Ä Å
;
''Å Ç
Ensure(( 
.(( 
Not(( 
<(( 
ValidationException(( *
>((* +
(((+ ,
employeeExists((, :
,((: ;
$str((< g
)((g h
;((h i
await** 
employeeRepository** $
.**$ %
AddAsync**% -
(**- .
employee**. 6
)**6 7
;**7 8
return,, 
typeAdapter,, 
.,, 
Adapt,, $
<,,$ %
GetEmployeeDto,,% 3
>,,3 4
(,,4 5
employee,,5 =
),,= >
;,,> ?
}-- 	
public// 
async// 
Task// 
<// 
GetEmployeeDto// (
>//( )
GetEmployee//* 5
(//5 6
int//6 9

employeeId//: D
)//D E
{00 	
var11 
employee11 
=11 
await11  
employeeRepository11! 3
.113 4
GetAsync114 <
(11< =

employeeId11= G
)11G H
;11H I
return22 
typeAdapter22 
.22 
Adapt22 $
<22$ %
GetEmployeeDto22% 3
>223 4
(224 5
employee225 =
)22= >
;22> ?
}33 	
public55 
async55 
Task55 
<55 
PagedResult55 %
<55% &
GetEmployeeDto55& 4
>554 5
>555 6
ListEmployees557 D
(55D E
PagingFilter55E Q

pageFilter55R \
)55\ ]
{66 	
var77 
	employees77 
=77 
await77 !
employeeRepository77" 4
.774 5
	FindAsync775 >
(77> ?

pageFilter77? I
.77I J
GetPagination77J W
(77W X
)77X Y
)77Y Z
;77Z [
var88 
page88 
=88 
typeAdapter88 "
.88" #
Adapt88# (
<88( )
List88) -
<88- .
GetEmployeeDto88. <
>88< =
>88= >
(88> ?
	employees88? H
)88H I
;88I J
return:: 
PagedResult:: 
.:: 
FromList:: '
(::' (
page::( ,
,::, -
	employees::. 7
.::7 8
	PageCount::8 A
,::A B
	employees::C L
.::L M

TotalCount::M W
)::W X
;::X Y
};; 	
public== 
async== 
Task== 
UpdateEmployee== (
(==( )
int==) ,
id==- /
)==/ 0
{>> 	
try?? 
{@@ 
employeeRepositoryAA "
.AA" #

UnitOfWorkAA# -
.AA- .
BeginTransactionAA. >
(AA> ?
)AA? @
;AA@ A
varCC 
employeeCC 
=CC 
awaitCC $
employeeRepositoryCC% 7
.CC7 8
GetAsyncCC8 @
(CC@ A
idCCA C
)CCC D
;CCD E
varDD 
	validatorDD 
=DD 
newDD  #
EmployeeValidatorDD$ 5
(DD5 6
)DD6 7
;DD7 8
varFF 
resultFF 
=FF 
	validatorFF &
.FF& '
ValidateFF' /
(FF/ 0
employeeFF0 8
)FF8 9
;FF9 :
resultGG 
.GG 
EnsureValidGG "
(GG" #
)GG# $
;GG$ %
awaitII 
employeeRepositoryII (
.II( )
UpdateAsyncII) 4
(II4 5
employeeII5 =
)II= >
;II> ?
employeeRepositoryKK "
.KK" #

UnitOfWorkKK# -
.KK- .
CommitKK. 4
(KK4 5
)KK5 6
;KK6 7
}LL 
catchMM 
(MM 
	ExceptionMM 
)MM 
{NN 
employeeRepositoryOO "
.OO" #

UnitOfWorkOO# -
.OO- .
RollbackOO. 6
(OO6 7
)OO7 8
;OO8 9
}PP 
}QQ 	
publicSS 
asyncSS 
TaskSS 
<SS 
GetEmployeeDtoSS (
>SS( )
UpdateEmployeeSS* 8
(SS8 9
intSS9 <

employeeIdSS= G
,SSG H
UpdateEmployeeDtoSSI Z
employeeDtoSS[ f
)SSf g
{TT 	
varUU 
	validatorUU 
=UU 
newUU 
EmployeeValidatorUU  1
(UU1 2
)UU2 3
;UU3 4
varWW 
employeeWW 
=WW 
awaitWW  
employeeRepositoryWW! 3
.WW3 4
GetAsyncWW4 <
(WW< =

employeeIdWW= G
)WWG H
;WWH I
ifYY 
(YY 
employeeYY 
.YY 
IsNullYY 
(YY  
)YY  !
)YY! "
returnZZ 
nullZZ 
;ZZ 
employee\\ 
.\\ 
	UpdateCpf\\ 
(\\ 
employeeDto\\ *
.\\* +
Cpf\\+ .
)\\. /
;\\/ 0
	validator^^ 
.^^ 
Validate^^ 
(^^ 
employee^^ '
)^^' (
.^^( )
EnsureValid^^) 4
(^^4 5
)^^5 6
;^^6 7
var`` 
employeeExists`` 
=``  
await``! &
employeeRepository``' 9
.``9 :
AnyAsync``: B
(``B C
new``C F
DirectSpecification``G Z
<``Z [
Employee``[ c
>``c d
(``d e
e``e f
=>``g i
e``j k
.``k l
Id``l n
!=``o q
employee``r z
.``z {
Id``{ }
&&	``~ Ä
e
``Å Ç
.
``Ç É
Cpf
``É Ü
==
``á â
employee
``ä í
.
``í ì
Cpf
``ì ñ
)
``ñ ó
)
``ó ò
;
``ò ô
Ensureaa 
.aa 
Notaa 
<aa 
ValidationExceptionaa *
>aa* +
(aa+ ,
employeeExistsaa, :
,aa: ;
$straa< g
)aag h
;aah i
awaitcc 
employeeRepositorycc $
.cc$ %
UpdateAsynccc% 0
(cc0 1
employeecc1 9
)cc9 :
;cc: ;
returnee 
typeAdapteree 
.ee 
Adaptee $
<ee$ %
GetEmployeeDtoee% 3
>ee3 4
(ee4 5
employeeee5 =
)ee= >
;ee> ?
}ff 	
}gg 
}hh ‡

nC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Application\Services\Employees\IEmployeeAppService.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Application $
.$ %
Services% -
.- .
	Employees. 7
{ 
public		 

	interface		 
IEmployeeAppService		 (
:		) *
IAppService		+ 6
{

 
Task 
< 
PagedResult 
< 
GetEmployeeDto '
>' (
>( )
ListEmployees* 7
(7 8
PagingFilter8 D

pageFilterE O
)O P
;P Q
Task 
< 
GetEmployeeDto 
> 
GetEmployee (
(( )
int) ,

employeeId- 7
)7 8
;8 9
Task 
< 
GetEmployeeDto 
> 
AddEmployee (
(( )
AddEmployeeDto) 7
employeeDto8 C
)C D
;D E
Task 
< 
GetEmployeeDto 
> 
UpdateEmployee +
(+ ,
int, /

employeeId0 :
,: ;
UpdateEmployeeDto< M
employeeDtoN Y
)Y Z
;Z [
} 
} Å
uC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Application\TypeAdapters\AutoMapper\AutoMapperTypeAdapter.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Application $
.$ %
TypeAdapters% 1
.1 2

AutoMapper2 <
{ 
public 

sealed 
class !
AutoMapperTypeAdapter -
:. /
ITypeAdapter0 <
{ 
public		 !
AutoMapperTypeAdapter		 $
(		$ %
)		% &
{

 	
Mapper 
. 

Initialize 
( 
config $
=>% '
{ 
config 
. 

AddProfile !
<! "
DomainToDtoProfile" 4
>4 5
(5 6
)6 7
;7 8
config 
. 

AddProfile !
<! "
DtoToDomainProfile" 4
>4 5
(5 6
)6 7
;7 8
} 
) 
; 
} 	
public 
TTarget 
Adapt 
< 
TSource $
,$ %
TTarget& -
>- .
(. /
TSource/ 6
source7 =
)= >
where 
TSource 
: 
class !
where 
TTarget 
: 
class !
,! "
new# &
(& '
)' (
{ 	
return 
Mapper 
. 
Map 
< 
TTarget %
>% &
(& '
source' -
)- .
;. /
} 	
public 
TTarget 
Adapt 
< 
TTarget $
>$ %
(% &
object& ,
source- 3
)3 4
where 
TTarget 
: 
class !
,! "
new# &
(& '
)' (
{ 	
return 
Mapper 
. 
Map 
< 
TTarget %
>% &
(& '
source' -
)- .
;. /
} 	
} 
} ¶
{C:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Application\TypeAdapters\AutoMapper\Profiles\DomainToDtoProfile.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Application $
.$ %
TypeAdapters% 1
.1 2

AutoMapper2 <
.< =
Profiles= E
{ 
internal 
class 
DomainToDtoProfile %
:& '
Profile( /
{ 
public		 
DomainToDtoProfile		 !
(		! "
)		" #
{

 	
	CreateMap 
< 
Employee 
, 
GetEmployeeDto  .
>. /
(/ 0
)0 1
. 
	ForMember 
( 
d 
=> 
d  !
.! "

EmployeeId" ,
,, -
opt. 1
=>2 4
opt5 8
.8 9
MapFrom9 @
(@ A
pA B
=>C E
pF G
.G H
IdH J
)J K
)K L
. 
	ForMember 
( 
d 
=> 
d  !
.! "
	FirstName" +
,+ ,
opt- 0
=>1 3
opt4 7
.7 8
MapFrom8 ?
(? @
p@ A
=>B D
pE F
.F G
NameG K
.K L
	FirstNameL U
)U V
)V W
. 
	ForMember 
( 
d 
=> 
d  !
.! "
LastName" *
,* +
opt, /
=>0 2
opt3 6
.6 7
MapFrom7 >
(> ?
p? @
=>A C
pD E
.E F
NameF J
.J K
LastNameK S
)S T
)T U
;U V
} 	
} 
} ¸
{C:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Application\TypeAdapters\AutoMapper\Profiles\DtoToDomainProfile.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Application $
.$ %
TypeAdapters% 1
.1 2

AutoMapper2 <
.< =
Profiles= E
{ 
internal 
class 
DtoToDomainProfile %
:& '
Profile( /
{ 
public 
DtoToDomainProfile !
(! "
)" #
{ 	
}

 	
} 
} 