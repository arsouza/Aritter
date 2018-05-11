í
NC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Business\BusinessRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Business  
{ 
public 

class 
BusinessRule 
< 
TEntity %
>% &
:' (
IBusinessRule) 6
<6 7
TEntity7 >
>> ?
where 
TEntity 
: 
class 
{		 
private

 
readonly

 
ISpecification

 '
<

' (
TEntity

( /
>

/ 0
rule

1 5
;

5 6
private 
readonly 
Action 
<  
TEntity  '
>' (
action) /
;/ 0
public 
BusinessRule 
( 
ISpecification *
<* +
TEntity+ 2
>2 3
rule4 8
,8 9
Action: @
<@ A
TEntityA H
>H I
actionJ P
)P Q
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
rule$ (
,( )
nameof* 0
(0 1
rule1 5
)5 6
,6 7
$"8 :,
 Please provide a valid non null : Z
{Z [
nameof[ a
(a b
ruleb f
)f g
}g h
 delegate instance.h {
"{ |
)| }
;} ~
Ensure 
. 
Argument 
. 
NotNull #
(# $
action$ *
,* +
nameof, 2
(2 3
action3 9
)9 :
,: ;
$"< >,
 Please provide a valid non null > ^
{^ _
nameof_ e
(e f
actionf l
)l m
}m n 
 delegate instance.	n Å
"
Å Ç
)
Ç É
;
É Ñ
this 
. 
rule 
= 
rule 
; 
this 
. 
action 
= 
action  
;  !
} 	
public 
void 
Evaluate 
( 
TEntity $
entity% +
)+ ,
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
entity$ *
,* +
nameof, 2
(2 3
entity3 9
)9 :
,: ;
$str< w
)w x
;x y
if 
( 
rule 
. 
IsSatisfiedBy "
(" #
entity# )
)) *
)* +
action 
( 
entity 
) 
; 
} 	
} 
} °#
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Business\BusinessRulesEvaluator.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Business  
{ 
public 

abstract 
class "
BusinessRulesEvaluator 0
<0 1
TEntity1 8
>8 9
:: ;#
IBusinessRulesEvaluator< S
<S T
TEntityT [
>[ \
where 
TEntity 
: 
class 
{ 
private		 
readonly		 

Dictionary		 #
<		# $
string		$ *
,		* +
IBusinessRule		, 9
<		9 :
TEntity		: A
>		A B
>		B C
rules		D I
=		J K
new		L O

Dictionary		P Z
<		Z [
string		[ a
,		a b
IBusinessRule		c p
<		p q
TEntity		q x
>		x y
>		y z
(		z {
)		{ |
;		| }
	protected 
virtual 
void 
AddRule &
(& '
string' -
ruleName. 6
,6 7
IBusinessRule8 E
<E F
TEntityF M
>M N
ruleO S
)S T
{ 	
Ensure 
. 
Argument 
. 
NotNullOrEmpty *
(* +
ruleName+ 3
,3 4
nameof5 ;
(; <
ruleName< D
)D E
,E F
$strG {
){ |
;| }
Ensure 
. 
Argument 
. 
NotNull #
(# $
rule$ (
,( )
nameof* 0
(0 1
rule1 5
)5 6
,6 7
$str8 y
)y z
;z {
Ensure 
. 
That 
( 
! 
rules 
. 
ContainsKey *
(* +
ruleName+ 3
)3 4
,4 5
$str	6 É
)
É Ñ
;
Ñ Ö
rules 
. 
Add 
( 
ruleName 
, 
rule  $
)$ %
;% &
} 	
	protected 
virtual 
void 

RemoveRule )
() *
string* 0
ruleName1 9
)9 :
{ 	
Ensure 
. 
Argument 
. 
NotNullOrEmpty *
(* +
ruleName+ 3
,3 4
nameof5 ;
(; <
ruleName< D
)D E
,E F
$strG u
)u v
;v w
rules 
. 
Remove 
( 
ruleName !
)! "
;" #
} 	
public 
virtual 
void 
Evaluate $
($ %
TEntity% ,
entity- 3
)3 4
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
entity$ *
,* +
nameof, 2
(2 3
entity3 9
)9 :
,: ;
$str	< ò
)
ò ô
;
ô ö
foreach 
( 
var 
key 
in 
rules  %
.% &
Keys& *
)* +
{ 
	Evauluate   
(   
entity    
,    !
key  " %
)  % &
;  & '
}!! 
}"" 	
private$$ 
void$$ 
	Evauluate$$ 
($$ 
TEntity$$ &
entity$$' -
,$$- .
string$$/ 5
ruleName$$6 >
)$$> ?
{%% 	
Ensure&& 
.&& 
Argument&& 
.&& 
NotNull&& #
(&&# $
entity&&$ *
,&&* +
nameof&&, 2
(&&2 3
entity&&3 9
)&&9 :
,&&: ;
$str&&< {
)&&{ |
;&&| }
if(( 
((( 
rules(( 
.(( 
ContainsKey(( !
(((! "
ruleName((" *
)((* +
)((+ ,
rules)) 
[)) 
ruleName)) 
])) 
.))  
Evaluate))  (
())( )
entity))) /
)))/ 0
;))0 1
}** 	
}++ 
},, Ò
OC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Business\IBusinessRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Business  
{ 
public 

	interface 
IBusinessRule "
<" #
TEntity# *
>* +
{ 
void 
Evaluate 
( 
TEntity 
entity $
)$ %
;% &
} 
} Ö
YC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Business\IBusinessRulesEvaluator.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Business  
{ 
public 

	interface #
IBusinessRulesEvaluator ,
<, -
TEntity- 4
>4 5
{ 
void 
Evaluate 
( 
TEntity 
entity $
)$ %
;% &
} 
} ﬂ
?C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Entity.cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

abstract 
class 
Entity  
:! "
IEntity# *
{ 
public 
virtual 
int 
Id 
{ 
get  #
;# $
	protected% .
set/ 2
;2 3
}4 5
public		 
virtual		 
Guid		 
Uid		 
{		  !
get		" %
;		% &
	protected		' 0
set		1 4
;		4 5
}		6 7
=		8 9
Guid		: >
.		> ?
NewGuid		? F
(		F G
)		G H
;		H I
	protected 
Entity 
( 
) 
: 
base !
(! "
)" #
{$ %
}& '
public 
bool 
IsTransient 
(  
)  !
=>" $
Id% '
==( *
default+ 2
;2 3
public 
override 
bool 
Equals #
(# $
object$ *
obj+ .
). /
{ 	
if 
( 
obj 
. 
IsNull 
( 
) 
|| 
!  !
obj! $
.$ %
Is% '
<' (
Entity( .
>. /
(/ 0
)0 1
)1 2
return 
false 
; 
if 
( 
ReferenceEquals 
(  
this  $
,$ %
obj& )
)) *
)* +
return 
true 
; 
Entity 
item 
= 
obj 
as  
Entity! '
;' (
if 
( 
item 
. 
IsTransient  
(  !
)! "
||# %
this& *
.* +
IsTransient+ 6
(6 7
)7 8
)8 9
return 
false 
; 
return 
item 
. 
Id 
== 
this "
." #
Id# %
;% &
} 	
public 
override 
int 
GetHashCode '
(' (
)( )
{   	
if!! 
(!! 
!!! 
IsTransient!! 
(!! 
)!! 
)!! 
return"" 
this"" 
."" 
Id"" 
."" 
GetHashCode"" *
(""* +
)""+ ,
^""- .
$num""/ 1
;""1 2
return$$ 
base$$ 
.$$ 
GetHashCode$$ #
($$# $
)$$$ %
;$$% &
}%% 	
public'' 
static'' 
bool'' 
operator'' #
==''$ &
(''& '
Entity''' -
left''. 2
,''2 3
Entity''4 :
right''; @
)''@ A
{(( 	
if)) 
()) 
Equals)) 
()) 
left)) 
,)) 
null)) !
)))! "
)))" #
return** 
Equals** 
(** 
right** #
,**# $
null**% )
)**) *
;*** +
return,, 
left,, 
.,, 
Equals,, 
(,, 
right,, $
),,$ %
;,,% &
}-- 	
public// 
static// 
bool// 
operator// #
!=//$ &
(//& '
Entity//' -
left//. 2
,//2 3
Entity//4 :
right//; @
)//@ A
{00 	
return11 
!11 
(11 
left11 
==11 
right11 "
)11" #
;11# $
}22 	
}33 
}44 û
@C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\IEntity.cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

	interface 
IEntity 
{ 
int 
Id 
{ 
get 
; 
} 
Guid		 
Uid		 
{		 
get		 
;		 
}		 
bool 
IsTransient 
( 
) 
; 
} 
} ˝
DC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\IRepository.cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

	interface 
IRepository  
{ 
IUnitOfWork 

UnitOfWork 
{  
get! $
;$ %
}& '
} 
} ›+
FC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\IRepository[].cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

	interface 
IRepository  
<  !
TEntity! (
>( )
:* +
IRepository, 7
where		 
TEntity		 
:		 
class		 
,		 
IEntity		 &
{

 
TEntity 
Get 
( 
int 
id 
) 
; 
Task 
< 
TEntity 
> 
GetAsync 
( 
int "
id# %
)% &
;& '
ICollection 
< 
TEntity 
> 
Find !
(! "
)" #
;# $
Task 
< 
ICollection 
< 
TEntity  
>  !
>! "
	FindAsync# ,
(, -
)- .
;. /
ICollection 
< 
TEntity 
> 
Find !
(! "
ISpecification" 0
<0 1
TEntity1 8
>8 9
specification: G
)G H
;H I
Task 
< 
ICollection 
< 
TEntity  
>  !
>! "
	FindAsync# ,
(, -
ISpecification- ;
<; <
TEntity< C
>C D
specificationE R
)R S
;S T

IPagedList 
< 
TEntity 
> 
Find  
(  !
IPagination! ,

pagination- 7
)7 8
;8 9
Task 
< 

IPagedList 
< 
TEntity 
>  
>  !
	FindAsync" +
(+ ,
IPagination, 7

pagination8 B
)B C
;C D

IPagedList 
< 
TEntity 
> 
Find  
(  !
ISpecification! /
</ 0
TEntity0 7
>7 8
specification9 F
,F G
IPaginationH S

paginationT ^
)^ _
;_ `
Task 
< 

IPagedList 
< 
TEntity 
>  
>  !
	FindAsync" +
(+ ,
ISpecification, :
<: ;
TEntity; B
>B C
specificationD Q
,Q R
IPaginationS ^

pagination_ i
)i j
;j k
bool 
Any 
( 
) 
; 
Task!! 
<!! 
bool!! 
>!! 
AnyAsync!! 
(!! 
)!! 
;!! 
bool## 
Any## 
(## 
ISpecification## 
<##  
TEntity##  '
>##' (
specification##) 6
)##6 7
;##7 8
Task%% 
<%% 
bool%% 
>%% 
AnyAsync%% 
(%% 
ISpecification%% *
<%%* +
TEntity%%+ 2
>%%2 3
specification%%4 A
)%%A B
;%%B C
void'' 
Add'' 
('' 
TEntity'' 
entity'' 
)''  
;''  !
Task)) 
AddAsync)) 
()) 
TEntity)) 
entity)) $
)))$ %
;))% &
void++ 
Add++ 
(++ 
IEnumerable++ 
<++ 
TEntity++ $
>++$ %
entities++& .
)++. /
;++/ 0
Task-- 
AddAsync-- 
(-- 
IEnumerable-- !
<--! "
TEntity--" )
>--) *
entities--+ 3
)--3 4
;--4 5
void// 
Update// 
(// 
TEntity// 
entity// "
)//" #
;//# $
Task11 
UpdateAsync11 
(11 
TEntity11  
entity11! '
)11' (
;11( )
void33 
Update33 
(33 
IEnumerable33 
<33  
TEntity33  '
>33' (
entities33) 1
)331 2
;332 3
Task55 
UpdateAsync55 
(55 
IEnumerable55 $
<55$ %
TEntity55% ,
>55, -
entities55. 6
)556 7
;557 8
void77 
Remove77 
(77 
TEntity77 
entity77 "
)77" #
;77# $
Task99 
RemoveAsync99 
(99 
TEntity99  
entity99! '
)99' (
;99( )
void;; 
Remove;; 
(;; 
IEnumerable;; 
<;;  
TEntity;;  '
>;;' (
entities;;) 1
);;1 2
;;;2 3
Task== 
RemoveAsync== 
(== 
IEnumerable== $
<==$ %
TEntity==% ,
>==, -
entities==. 6
)==6 7
;==7 8
void?? 
Remove?? 
(?? 
ISpecification?? "
<??" #
TEntity??# *
>??* +
specification??, 9
)??9 :
;??: ;
TaskAA 
RemoveAsyncAA 
(AA 
ISpecificationAA '
<AA' (
TEntityAA( /
>AA/ 0
specificationAA1 >
)AA> ?
;AA? @
}BB 
}CC ª
DC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\IUnitOfWork.cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ 
void 
BeginTransaction 
( 
) 
;  
void 
Commit 
( 
) 
; 
void		 
Rollback		 
(		 
)		 
;		 
}

 
} ˝
OC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Services\DomainService.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Services  
{ 
public 

abstract 
class 
DomainService '
:( )
IDomainService* 8
{ 
} 
} ¬
PC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Services\IDomainService.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Services  
{ 
public 

	interface 
IDomainService #
{ 
} 
} Ω
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\AndSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

sealed 
class 
AndSpecification (
<( )
TEntity) 0
>0 1
:2 3"
CompositeSpecification4 J
<J K
TEntityK R
>R S
where 
TEntity 
: 
class 
{		 
private

 
readonly

 
ISpecification

 '
<

' (
TEntity

( /
>

/ 0"
rightSideSpecification

1 G
=

H I
null

J N
;

N O
private 
readonly 
ISpecification '
<' (
TEntity( /
>/ 0!
leftSideSpecification1 F
=G H
nullI M
;M N
public 
AndSpecification 
(  
ISpecification  .
<. /
TEntity/ 6
>6 7!
leftSideSpecification8 M
,M N
ISpecificationO ]
<] ^
TEntity^ e
>e f"
rightSideSpecificationg }
)} ~
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $!
leftSideSpecification$ 9
,9 :
nameof; A
(A B!
leftSideSpecificationB W
)W X
)X Y
;Y Z
Ensure 
. 
Argument 
. 
NotNull #
(# $"
rightSideSpecification$ :
,: ;
nameof< B
(B C"
rightSideSpecificationC Y
)Y Z
)Z [
;[ \
this 
. !
leftSideSpecification &
=' (!
leftSideSpecification) >
;> ?
this 
. "
rightSideSpecification '
=( )"
rightSideSpecification* @
;@ A
} 	
public 
override 
ISpecification &
<& '
TEntity' .
>. /!
LeftSideSpecification0 E
=>F H!
leftSideSpecificationI ^
;^ _
public 
override 
ISpecification &
<& '
TEntity' .
>. /"
RightSideSpecification0 F
=>G I"
rightSideSpecificationJ `
;` a
public 
override 

Expression "
<" #
Func# '
<' (
TEntity( /
,/ 0
bool1 5
>5 6
>6 7
SatisfiedBy8 C
(C D
)D E
{ 	

Expression 
< 
Func 
< 
TEntity #
,# $
bool% )
>) *
>* +
left, 0
=1 2!
leftSideSpecification3 H
.H I
SatisfiedByI T
(T U
)U V
;V W

Expression 
< 
Func 
< 
TEntity #
,# $
bool% )
>) *
>* +
right, 1
=2 3"
rightSideSpecification4 J
.J K
SatisfiedByK V
(V W
)W X
;X Y
return 
left 
. 
And 
( 
right !
)! "
;" #
}   	
}!! 
}"" ˇ
^C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\CompositeSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

abstract 
class "
CompositeSpecification 0
<0 1
TEntity1 8
>8 9
:: ;
Specification< I
<I J
TEntityJ Q
>Q R
where	 
TEntity 
: 
class 
{ 
public 
abstract 
ISpecification &
<& '
TEntity' .
>. /!
LeftSideSpecification0 E
{F G
getH K
;K L
}M N
public 
abstract 
ISpecification &
<& '
TEntity' .
>. /"
RightSideSpecification0 F
{G H
getI L
;L M
}N O
}		 
}

 â
[C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\DirectSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

class 
DirectSpecification $
<$ %
TEntity% ,
>, -
:. /
Specification0 =
<= >
TEntity> E
>E F
where 
TEntity 
: 
class 
{		 
private

 
readonly

 

Expression

 #
<

# $
Func

$ (
<

( )
TEntity

) 0
,

0 1
bool

2 6
>

6 7
>

7 8
matchingCriteria

9 I
;

I J
public 
DirectSpecification "
(" #

Expression# -
<- .
Func. 2
<2 3
TEntity3 :
,: ;
bool< @
>@ A
>A B
matchingCriteriaC S
)S T
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
matchingCriteria$ 4
,4 5
nameof6 <
(< =
matchingCriteria= M
)M N
)N O
;O P
this 
. 
matchingCriteria !
=" #
matchingCriteria$ 4
;4 5
} 	
public 
override 

Expression "
<" #
Func# '
<' (
TEntity( /
,/ 0
bool1 5
>5 6
>6 7
SatisfiedBy8 C
(C D
)D E
=>F H
matchingCriteriaI Y
;Y Z
} 
} ˛ 
YC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\ExpressionBuilder.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

static 
class 
ExpressionBuilder )
{ 
internal		 
static		 

Expression		 "
<		" #
T		# $
>		$ %
Compose		& -
<		- .
T		. /
>		/ 0
(		0 1
this		1 5

Expression		6 @
<		@ A
T		A B
>		B C
first		D I
,		I J

Expression		K U
<		U V
T		V W
>		W X
second		Y _
,		_ `
Func		a e
<		e f

Expression		f p
,		p q

Expression		r |
,		| }

Expression			~ à
>
		à â
merge
		ä è
)
		è ê
{

 	
var 
map 
= 
first 
. 

Parameters &
. 
Select 
( 
( 
parameterExpression ,
,, -
index. 3
)3 4
=>5 7
new8 ;
{ 
FirstParameter "
=# $
parameterExpression% 8
,8 9
SecondParameter #
=$ %
second& ,
., -

Parameters- 7
[7 8
index8 =
]= >
} 
) 
. 
ToDictionary 
( 
p 
=>  "
p# $
.$ %
SecondParameter% 4
,4 5
p6 7
=>8 :
p; <
.< =
FirstParameter= K
)K L
;L M
var 

secondBody 
= 
ParameterRebinder .
.. /
ReplaceParameters/ @
(@ A
mapA D
,D E
secondF L
.L M
BodyM Q
)Q R
;R S
return 

Expression 
. 
Lambda $
<$ %
T% &
>& '
(' (
merge( -
(- .
first. 3
.3 4
Body4 8
,8 9

secondBody: D
)D E
,E F
firstG L
.L M

ParametersM W
)W X
;X Y
} 	
public 
static 

Expression  
<  !
Func! %
<% &
T& '
,' (
bool) -
>- .
>. /
And0 3
<3 4
T4 5
>5 6
(6 7
this7 ;

Expression< F
<F G
FuncG K
<K L
TL M
,M N
boolO S
>S T
>T U
firstV [
,[ \

Expression] g
<g h
Funch l
<l m
Tm n
,n o
boolp t
>t u
>u v
secondw }
)} ~
=> 
first 
. 
Compose 
( 
second #
,# $

Expression% /
./ 0
AndAlso0 7
)7 8
;8 9
public 
static 

Expression  
<  !
Func! %
<% &
T& '
,' (
bool) -
>- .
>. /
Or0 2
<2 3
T3 4
>4 5
(5 6
this6 :

Expression; E
<E F
FuncF J
<J K
TK L
,L M
boolN R
>R S
>S T
firstU Z
,Z [

Expression\ f
<f g
Funcg k
<k l
Tl m
,m n
boolo s
>s t
>t u
secondv |
)| }
=> 
first 
. 
Compose 
( 
second #
,# $

Expression% /
./ 0
OrElse0 6
)6 7
;7 8
} 
} ∞
VC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\ISpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

	interface 
ISpecification #
<# $
TEntity$ +
>+ ,
where 
TEntity 
: 
class 
{ 

Expression		 
<		 
Func		 
<		 
TEntity		 
,		  
bool		! %
>		% &
>		& '
SatisfiedBy		( 3
(		3 4
)		4 5
;		5 6
bool

 
IsSatisfiedBy

 
(

 
TEntity

 "
entity

# )
)

) *
;

* +
} 
} 
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\NotSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

sealed 
class 
NotSpecification (
<( )
TEntity) 0
>0 1
:2 3
Specification4 A
<A B
TEntityB I
>I J
where		 
TEntity		 
:		 
class		 
{

 
private 
readonly 

Expression #
<# $
Func$ (
<( )
TEntity) 0
,0 1
bool2 6
>6 7
>7 8
originalCriteria9 I
;I J
public 
NotSpecification 
(  
ISpecification  .
<. /
TEntity/ 6
>6 7!
originalSpecification8 M
)M N
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $!
originalSpecification$ 9
,9 :
nameof; A
(A B!
originalSpecificationB W
)W X
)X Y
;Y Z
originalCriteria 
= !
originalSpecification 4
.4 5
SatisfiedBy5 @
(@ A
)A B
;B C
} 	
public 
override 

Expression "
<" #
Func# '
<' (
TEntity( /
,/ 0
bool1 5
>5 6
>6 7
SatisfiedBy8 C
(C D
)D E
=> 

Expression 
. 
Lambda  
<  !
Func! %
<% &
TEntity& -
,- .
bool/ 3
>3 4
>4 5
(5 6

Expression6 @
.@ A
NotA D
(D E
originalCriteriaE U
.U V
BodyV Z
)Z [
,[ \
originalCriteria] m
.m n

Parametersn x
.x y
Singley 
(	 Ä
)
Ä Å
)
Å Ç
;
Ç É
} 
} π
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\OrSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

sealed 
class 
OrSpecification '
<' (
TEntity( /
>/ 0
:1 2"
CompositeSpecification3 I
<I J
TEntityJ Q
>Q R
where	 
TEntity 
: 
class 
{		 
private

 
readonly

 
ISpecification

 '
<

' (
TEntity

( /
>

/ 0"
rightSideSpecification

1 G
=

H I
null

J N
;

N O
private 
readonly 
ISpecification '
<' (
TEntity( /
>/ 0!
leftSideSpecification1 F
=G H
nullI M
;M N
public 
OrSpecification 
( 
ISpecification -
<- .
TEntity. 5
>5 6!
leftSideSpecification7 L
,L M
ISpecificationN \
<\ ]
TEntity] d
>d e"
rightSideSpecificationf |
)| }
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $!
leftSideSpecification$ 9
,9 :
nameof; A
(A B!
leftSideSpecificationB W
)W X
)X Y
;Y Z
Ensure 
. 
Argument 
. 
NotNull #
(# $"
rightSideSpecification$ :
,: ;
nameof< B
(B C"
rightSideSpecificationC Y
)Y Z
)Z [
;[ \
this 
. !
leftSideSpecification &
=' (!
leftSideSpecification) >
;> ?
this 
. "
rightSideSpecification '
=( )"
rightSideSpecification* @
;@ A
} 	
public 
override 
ISpecification &
<& '
TEntity' .
>. /!
LeftSideSpecification0 E
=>F H!
leftSideSpecificationI ^
;^ _
public 
override 
ISpecification &
<& '
TEntity' .
>. /"
RightSideSpecification0 F
=>G I"
rightSideSpecificationJ `
;` a
public 
override 

Expression "
<" #
Func# '
<' (
TEntity( /
,/ 0
bool1 5
>5 6
>6 7
SatisfiedBy8 C
(C D
)D E
{ 	

Expression 
< 
Func 
< 
TEntity #
,# $
bool% )
>) *
>* +
left, 0
=1 2!
leftSideSpecification3 H
.H I
SatisfiedByI T
(T U
)U V
;V W

Expression 
< 
Func 
< 
TEntity #
,# $
bool% )
>) *
>* +
right, 1
=2 3"
rightSideSpecification4 J
.J K
SatisfiedByK V
(V W
)W X
;X Y
return 
left 
. 
Or 
( 
right  
)  !
;! "
}   	
}!! 
}"" ë
ZC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\ParametersRebinder.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
internal 
sealed 
class 
ParameterRebinder +
:, -
ExpressionVisitor. ?
{ 
private 
readonly 

Dictionary #
<# $
ParameterExpression$ 7
,7 8
ParameterExpression9 L
>L M
mapN Q
;Q R
public

 
ParameterRebinder

  
(

  !

Dictionary

! +
<

+ ,
ParameterExpression

, ?
,

? @
ParameterExpression

A T
>

T U
map

V Y
)

Y Z
{ 	
this 
. 
map 
= 
map 
?? 
new !

Dictionary" ,
<, -
ParameterExpression- @
,@ A
ParameterExpressionB U
>U V
(V W
)W X
;X Y
} 	
public 
static 

Expression  
ReplaceParameters! 2
(2 3

Dictionary3 =
<= >
ParameterExpression> Q
,Q R
ParameterExpressionS f
>f g
maph k
,k l

Expressionm w
expx {
){ |
=> 
new 
ParameterRebinder $
($ %
map% (
)( )
.) *
Visit* /
(/ 0
exp0 3
)3 4
;4 5
	protected 
override 

Expression %
VisitParameter& 4
(4 5
ParameterExpression5 H
nodeI M
)M N
{ 	
var 
replacement 
= 
map !
.! "
GetValueOrDefault" 3
(3 4
node4 8
)8 9
;9 :
node 
= 
replacement 
; 
return 
base 
. 
VisitParameter &
(& '
node' +
)+ ,
;, -
} 	
} 
} ¨
UC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\Specification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

abstract 
class 
Specification '
<' (
TEntity( /
>/ 0
:1 2
ISpecification3 A
<A B
TEntityB I
>I J
where	 
TEntity 
: 
class 
{ 
public		 
static		 
Specification		 #
<		# $
TEntity		$ +
>		+ ,
operator		- 5
&		6 7
(		7 8
Specification		8 E
<		E F
TEntity		F M
>		M N!
leftSideSpecification		O d
,		d e
Specification		f s
<		s t
TEntity		t {
>		{ |#
rightSideSpecification			} ì
)
		ì î
=>

 
new

 
AndSpecification

 #
<

# $
TEntity

$ +
>

+ ,
(

, -!
leftSideSpecification

- B
,

B C"
rightSideSpecification

D Z
)

Z [
;

[ \
public 
static 
Specification #
<# $
TEntity$ +
>+ ,
operator- 5
|6 7
(7 8
Specification8 E
<E F
TEntityF M
>M N!
leftSideSpecificationO d
,d e
Specificationf s
<s t
TEntityt {
>{ |#
rightSideSpecification	} ì
)
ì î
=> 
new 
OrSpecification "
<" #
TEntity# *
>* +
(+ ,!
leftSideSpecification, A
,A B"
rightSideSpecificationC Y
)Y Z
;Z [
public 
static 
Specification #
<# $
TEntity$ +
>+ ,
operator- 5
!6 7
(7 8
Specification8 E
<E F
TEntityF M
>M N
specificationO \
)\ ]
=>^ `
newa d
NotSpecificatione u
<u v
TEntityv }
>} ~
(~ 
specification	 å
)
å ç
;
ç é
public 
static 
bool 
operator #
false$ )
() *
Specification* 7
<7 8
TEntity8 ?
>? @
specificationA N
)N O
=>P R
falseS X
;X Y
public 
static 
bool 
operator #
true$ (
(( )
Specification) 6
<6 7
TEntity7 >
>> ?
specification@ M
)M N
=>O Q
falseR W
;W X
public 
virtual 
bool 
IsSatisfiedBy )
() *
TEntity* 1
entity2 8
)8 9
=>: <
SatisfiedBy= H
(H I
)I J
.J K
CompileK R
(R S
)S T
.T U
InvokeU [
([ \
entity\ b
)b c
;c d
public 
abstract 

Expression "
<" #
Func# '
<' (
TEntity( /
,/ 0
bool1 5
>5 6
>6 7
SatisfiedBy8 C
(C D
)D E
;E F
} 
} ˜	
YC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Specifications\TrueSpecification.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Specifications &
{ 
public 

sealed 
class 
TrueSpecification )
<) *
TEntity* 1
>1 2
:3 4
Specification5 B
<B C
TEntityC J
>J K
where 
TEntity 
: 
class 
{ 
public		 
override		 

Expression		 "
<		" #
Func		# '
<		' (
TEntity		( /
,		/ 0
bool		1 5
>		5 6
>		6 7
SatisfiedBy		8 C
(		C D
)		D E
{

 	
bool 
result 
= 
true 
; 

Expression 
< 
Func 
< 
TEntity #
,# $
bool% )
>) *
>* +
trueExpression, :
=; <
t= >
=>? A
resultB H
;H I
return 
trueExpression !
;! "
} 	
} 
} ø
mC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Configurations\BasePropertyConfiguration.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Configurations$ 2
{ 
public 

abstract 
class %
BasePropertyConfiguration 3
<3 4

TValidable4 >
,> ?
TProp@ E
>E F
whereG L

TValidableM W
:X Y
classZ _
{ 
	protected		 %
BasePropertyConfiguration		 +
(		+ ,
ValidationContract		, >
<		> ?

TValidable		? I
>		I J
contract		K S
,		S T

Expression		U _
<		_ `
Func		` d
<		d e

TValidable		e o
,		o p
TProp		q v
>		v w
>		w x

expression			y É
)
		É Ñ
{

 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
contract$ ,
,, -
nameof. 4
(4 5
contract5 =
)= >
)> ?
;? @
Ensure 
. 
Argument 
. 
NotNull #
(# $

expression$ .
,. /
nameof0 6
(6 7

expression7 A
)A B
)B C
;C D
Contract 
= 
contract 
;  

Expression 
= 

expression #
;# $
} 	
public 
ValidationContract !
<! "

TValidable" ,
>, -
Contract. 6
{7 8
get9 <
;< =
	protected> G
setH K
;K L
}M N
public 

Expression 
< 
Func 
< 

TValidable )
,) *
TProp+ 0
>0 1
>1 2

Expression3 =
{> ?
get@ C
;C D
	protectedE N
setO R
;R S
}T U
} 
} á5
sC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Configurations\CollectionPropertyConfiguration.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Configurations$ 2
{ 
public		 

sealed		 
class		 +
CollectionPropertyConfiguration		 7
<		7 8

TValidable		8 B
>		B C
:		D E%
BasePropertyConfiguration		F _
<		_ `

TValidable		` j
,		j k
ICollection		l w
>		w x
where		y ~

TValidable			 â
:
		ä ã
class
		å ë
{

 
public +
CollectionPropertyConfiguration .
(. /
ValidationContract/ A
<A B

TValidableB L
>L M
contractN V
,V W

ExpressionX b
<b c
Funcc g
<g h

TValidableh r
,r s
ICollectiont 
>	 Ä
>
Ä Å

expression
Ç å
)
å ç
:
é è
base
ê î
(
î ï
contract
ï ù
,
ù û

expression
ü ©
)
© ™
{
´ ¨
}
≠ Æ
public +
CollectionPropertyConfiguration .
<. /

TValidable/ 9
>9 :

IsRequired; E
(E F
)F G
{ 	
return 

IsRequired 
( 
null "
)" #
;# $
} 	
public +
CollectionPropertyConfiguration .
<. /

TValidable/ 9
>9 :

IsRequired; E
(E F
stringF L
messageM T
)T U
{ 	
Contract 
. 
AddRule 
( 
new  
RequiredRule! -
<- .

TValidable. 8
,8 9
ICollection: E
>E F
(F G

ExpressionG Q
,Q R
messageS Z
)Z [
)[ \
;\ ]
return 
this 
; 
} 	
public +
CollectionPropertyConfiguration .
<. /

TValidable/ 9
>9 :
HasMinCount; F
(F G
intG J
minCountK S
)S T
{ 	
return 
HasMinCount 
( 
minCount '
,' (
null) -
)- .
;. /
} 	
public +
CollectionPropertyConfiguration .
<. /

TValidable/ 9
>9 :
HasMinCount; F
(F G
intG J
minCountK S
,S T
stringU [
message\ c
)c d
{ 	
Contract 
. 
AddRule 
( 
new  
MinCountRule! -
<- .

TValidable. 8
>8 9
(9 :

Expression: D
,D E
minCountF N
,N O
messageP W
)W X
)X Y
;Y Z
return   
this   
;   
}!! 	
public## +
CollectionPropertyConfiguration## .
<##. /

TValidable##/ 9
>##9 :
HasMaxCount##; F
(##F G
int##G J
maxCount##K S
)##S T
{$$ 	
return%% 
HasMaxCount%% 
(%% 
maxCount%% '
,%%' (
null%%) -
)%%- .
;%%. /
}&& 	
public(( +
CollectionPropertyConfiguration(( .
<((. /

TValidable((/ 9
>((9 :
HasMaxCount((; F
(((F G
int((G J
maxCount((K S
,((S T
string((U [
message((\ c
)((c d
{)) 	
Contract** 
.** 
AddRule** 
(** 
new**  
MaxCountRule**! -
<**- .

TValidable**. 8
>**8 9
(**9 :

Expression**: D
,**D E
maxCount**F N
,**N O
message**P W
)**W X
)**X Y
;**Y Z
return++ 
this++ 
;++ 
},, 	
public.. +
CollectionPropertyConfiguration.. .
<... /

TValidable../ 9
>..9 :
	HasCustom..; D
(..D E
Func..E I
<..I J

TValidable..J T
,..T U
bool..V Z
>..Z [
validateFunc..\ h
)..h i
{// 	
return00 
	HasCustom00 
(00 
validateFunc00 )
,00) *
null00+ /
)00/ 0
;000 1
}11 	
public33 +
CollectionPropertyConfiguration33 .
<33. /

TValidable33/ 9
>339 :
	HasCustom33; D
(33D E
Func33E I
<33I J

TValidable33J T
,33T U
bool33V Z
>33Z [
validateFunc33\ h
,33h i
string33j p
message33q x
)33x y
{44 	
Contract55 
.55 
AddRule55 
(55 
new55  

CustomRule55! +
<55+ ,

TValidable55, 6
>556 7
(557 8
validateFunc558 D
,55D E
message55F M
)55M N
)55N O
;55O P
return66 
this66 
;66 
}77 	
public99 +
CollectionPropertyConfiguration99 .
<99. /

TValidable99/ 9
>999 :
HasSpecification99; K
(99K L
ISpecification99L Z
<99Z [

TValidable99[ e
>99e f
specification99g t
)99t u
{:: 	
return;; 
HasSpecification;; #
(;;# $
specification;;$ 1
,;;1 2
null;;3 7
);;7 8
;;;8 9
}<< 	
public>> +
CollectionPropertyConfiguration>> .
<>>. /

TValidable>>/ 9
>>>9 :
HasSpecification>>; K
(>>K L
ISpecification>>L Z
<>>Z [

TValidable>>[ e
>>>e f
specification>>g t
,>>t u
string>>v |
message	>>} Ñ
)
>>Ñ Ö
{?? 	
Contract@@ 
.@@ 
AddRule@@ 
(@@ 
new@@  
SpecificationRule@@! 2
<@@2 3

TValidable@@3 =
>@@= >
(@@> ?
specification@@? L
,@@L M
message@@N U
)@@U V
)@@V W
;@@W X
returnAA 
thisAA 
;AA 
}BB 	
}CC 
}DD À&
oC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Configurations\ObjectPropertyConfiguration.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Configurations$ 2
{ 
public 

class '
ObjectPropertyConfiguration ,
<, -

TValidable- 7
,7 8
TProp9 >
>> ?
:@ A%
BasePropertyConfigurationB [
<[ \

TValidable\ f
,f g
TProph m
>m n
whereo t

TValidableu 
:
Ä Å
class
Ç á
where
à ç
TProp
é ì
:
î ï
class
ñ õ
{		 
public

 '
ObjectPropertyConfiguration

 *
(

* +
ValidationContract

+ =
<

= >

TValidable

> H
>

H I
contract

J R
,

R S

Expression

T ^
<

^ _
Func

_ c
<

c d

TValidable

d n
,

n o
TProp

p u
>

u v
>

v w

expression	

x Ç
)


Ç É
:


Ñ Ö
base


Ü ä
(


ä ã
contract


ã ì
,


ì î

expression


ï ü
)


ü †
{


° ¢
}


£ §
public 
virtual '
ObjectPropertyConfiguration 2
<2 3

TValidable3 =
,= >
TProp? D
>D E

IsRequiredF P
(P Q
)Q R
{ 	
return 

IsRequired 
( 
null "
)" #
;# $
} 	
public 
virtual '
ObjectPropertyConfiguration 2
<2 3

TValidable3 =
,= >
TProp? D
>D E

IsRequiredF P
(P Q
stringQ W
messageX _
)_ `
{ 	
Contract 
. 
AddRule 
( 
new  
RequiredRule! -
<- .

TValidable. 8
,8 9
TProp: ?
>? @
(@ A

ExpressionA K
,K L
messageM T
)T U
)U V
;V W
return 
this 
; 
} 	
public '
ObjectPropertyConfiguration *
<* +

TValidable+ 5
,5 6
TProp7 <
>< =
	HasCustom> G
(G H
FuncH L
<L M

TValidableM W
,W X
boolY ]
>] ^
validateFunc_ k
)k l
{ 	
return 
	HasCustom 
( 
validateFunc )
,) *
null+ /
)/ 0
;0 1
} 	
public '
ObjectPropertyConfiguration *
<* +

TValidable+ 5
,5 6
TProp7 <
>< =
	HasCustom> G
(G H
FuncH L
<L M

TValidableM W
,W X
boolY ]
>] ^
validateFunc_ k
,k l
stringm s
messaget {
){ |
{ 	
Contract 
. 
AddRule 
( 
new  

CustomRule! +
<+ ,

TValidable, 6
>6 7
(7 8
validateFunc8 D
,D E
messageF M
)M N
)N O
;O P
return 
this 
; 
}   	
public"" '
ObjectPropertyConfiguration"" *
<""* +

TValidable""+ 5
,""5 6
TProp""7 <
>""< =
HasSpecification""> N
(""N O
ISpecification""O ]
<""] ^

TValidable""^ h
>""h i
specification""j w
)""w x
{## 	
return$$ 
HasSpecification$$ #
($$# $
specification$$$ 1
,$$1 2
null$$3 7
)$$7 8
;$$8 9
}%% 	
public'' '
ObjectPropertyConfiguration'' *
<''* +

TValidable''+ 5
,''5 6
TProp''7 <
>''< =
HasSpecification''> N
(''N O
ISpecification''O ]
<''] ^

TValidable''^ h
>''h i
specification''j w
,''w x
string''y 
message
''Ä á
)
''á à
{(( 	
Contract)) 
.)) 
AddRule)) 
()) 
new))  
SpecificationRule))! 2
<))2 3

TValidable))3 =
>))= >
())> ?
specification))? L
,))L M
message))N U
)))U V
)))V W
;))W X
return** 
this** 
;** 
}++ 	
},, 
}-- àC
rC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Configurations\PrimitivePropertyConfiguration.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Configurations$ 2
{ 
public 

sealed 
class *
PrimitivePropertyConfiguration 6
<6 7

TValidable7 A
,A B
TPropC H
>H I
:J K%
BasePropertyConfigurationL e
<e f

TValidablef p
,p q
TPropr w
>w x
wherey ~

TValidable	 â
:
ä ã
class
å ë
where
í ó
TProp
ò ù
:
û ü
struct
† ¶
{		 
public

 *
PrimitivePropertyConfiguration

 -
(

- .
ValidationContract

. @
<

@ A

TValidable

A K
>

K L
contract

M U
,

U V

Expression

W a
<

a b
Func

b f
<

f g

TValidable

g q
,

q r
TProp

s x
>

x y
>

y z

expression	

{ Ö
)


Ö Ü
:


á à
base


â ç
(


ç é
contract


é ñ
,


ñ ó

expression


ò ¢
)


¢ £
{


§ •
}


¶ ß
public *
PrimitivePropertyConfiguration -
<- .

TValidable. 8
,8 9
TProp: ?
>? @

IsRequiredA K
(K L
)L M
{ 	
return 

IsRequired 
( 
null "
)" #
;# $
} 	
public *
PrimitivePropertyConfiguration -
<- .

TValidable. 8
,8 9
TProp: ?
>? @

IsRequiredA K
(K L
stringL R
messageS Z
)Z [
{ 	
Contract 
. 
AddRule 
( 
new  
RequiredRule! -
<- .

TValidable. 8
,8 9
TProp: ?
>? @
(@ A

ExpressionA K
,K L
messageM T
)T U
)U V
;V W
return 
this 
; 
} 	
public *
PrimitivePropertyConfiguration -
<- .

TValidable. 8
,8 9
TProp: ?
>? @
HasMinValueA L
(L M
TPropM R
minValueS [
)[ \
{ 	
return 
HasMinValue 
( 
minValue '
,' (
null) -
)- .
;. /
} 	
public *
PrimitivePropertyConfiguration -
<- .

TValidable. 8
,8 9
TProp: ?
>? @
HasMinValueA L
(L M
TPropM R
minValueS [
,[ \
string] c
messaged k
)k l
{ 	
Contract 
. 
AddRule 
( 
new  
MinRule! (
<( )

TValidable) 3
,3 4
TProp5 :
>: ;
(; <

Expression< F
,F G
minValueH P
,P Q
messageR Y
)Y Z
)Z [
;[ \
return 
this 
; 
}   	
public"" *
PrimitivePropertyConfiguration"" -
<""- .

TValidable"". 8
,""8 9
TProp"": ?
>""? @
HasMaxValue""A L
(""L M
TProp""M R
maxValue""S [
)""[ \
{## 	
return$$ 
HasMaxValue$$ 
($$ 
maxValue$$ '
,$$' (
null$$) -
)$$- .
;$$. /
}%% 	
public'' *
PrimitivePropertyConfiguration'' -
<''- .

TValidable''. 8
,''8 9
TProp'': ?
>''? @
HasMaxValue''A L
(''L M
TProp''M R
maxValue''S [
,''[ \
string''] c
message''d k
)''k l
{(( 	
Contract)) 
.)) 
AddRule)) 
()) 
new))  
MaxRule))! (
<))( )

TValidable))) 3
,))3 4
TProp))5 :
>)): ;
()); <

Expression))< F
,))F G
maxValue))H P
,))P Q
message))R Y
)))Y Z
)))Z [
;))[ \
return** 
this** 
;** 
}++ 	
public-- *
PrimitivePropertyConfiguration-- -
<--- .

TValidable--. 8
,--8 9
TProp--: ?
>--? @
HasRange--A I
(--I J
TProp--J O
min--P S
,--S T
TProp--U Z
max--[ ^
)--^ _
{.. 	
return// 
HasRange// 
(// 
min// 
,//  
max//! $
,//$ %
null//& *
)//* +
;//+ ,
}00 	
public22 *
PrimitivePropertyConfiguration22 -
<22- .

TValidable22. 8
,228 9
TProp22: ?
>22? @
HasRange22A I
(22I J
TProp22J O
min22P S
,22S T
TProp22U Z
max22[ ^
,22^ _
string22` f
message22g n
)22n o
{33 	
Contract44 
.44 
AddRule44 
(44 
new44  
	RangeRule44! *
<44* +

TValidable44+ 5
,445 6
TProp447 <
>44< =
(44= >

Expression44> H
,44H I
min44J M
,44M N
max44O R
,44R S
message44T [
)44[ \
)44\ ]
;44] ^
return55 
this55 
;55 
}66 	
public88 *
PrimitivePropertyConfiguration88 -
<88- .

TValidable88. 8
,888 9
TProp88: ?
>88? @
	HasCustom88A J
(88J K
Func88K O
<88O P

TValidable88P Z
,88Z [
bool88\ `
>88` a
validateFunc88b n
)88n o
{99 	
return:: 
	HasCustom:: 
(:: 
validateFunc:: )
,::) *
null::+ /
)::/ 0
;::0 1
};; 	
public== *
PrimitivePropertyConfiguration== -
<==- .

TValidable==. 8
,==8 9
TProp==: ?
>==? @
	HasCustom==A J
(==J K
Func==K O
<==O P

TValidable==P Z
,==Z [
bool==\ `
>==` a
validateFunc==b n
,==n o
string==p v
message==w ~
)==~ 
{>> 	
Contract?? 
.?? 
AddRule?? 
(?? 
new??  

CustomRule??! +
<??+ ,

TValidable??, 6
>??6 7
(??7 8
validateFunc??8 D
,??D E
message??F M
)??M N
)??N O
;??O P
return@@ 
this@@ 
;@@ 
}AA 	
publicCC *
PrimitivePropertyConfigurationCC -
<CC- .

TValidableCC. 8
,CC8 9
TPropCC: ?
>CC? @
HasSpecificationCCA Q
(CCQ R
ISpecificationCCR `
<CC` a

TValidableCCa k
>CCk l
specificationCCm z
)CCz {
{DD 	
returnEE 
HasSpecificationEE #
(EE# $
specificationEE$ 1
,EE1 2
nullEE3 7
)EE7 8
;EE8 9
}FF 	
publicHH *
PrimitivePropertyConfigurationHH -
<HH- .

TValidableHH. 8
,HH8 9
TPropHH: ?
>HH? @
HasSpecificationHHA Q
(HHQ R
ISpecificationHHR `
<HH` a

TValidableHHa k
>HHk l
specificationHHm z
,HHz {
string	HH| Ç
message
HHÉ ä
)
HHä ã
{II 	
ContractJJ 
.JJ 
AddRuleJJ 
(JJ 
newJJ  
SpecificationRuleJJ! 2
<JJ2 3

TValidableJJ3 =
>JJ= >
(JJ> ?
specificationJJ? L
,JJL M
messageJJN U
)JJU V
)JJV W
;JJW X
returnKK 
thisKK 
;KK 
}LL 	
}MM 
}NN ≤^
oC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Configurations\StringPropertyConfiguration.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Configurations$ 2
{ 
public 

sealed 
class '
StringPropertyConfiguration 3
<3 4

TValidable4 >
>> ?
:@ A%
BasePropertyConfigurationB [
<[ \

TValidable\ f
,f g
stringh n
>n o
wherep u

TValidable	v Ä
:
Å Ç
class
É à
{		 
public

 '
StringPropertyConfiguration

 *
(

* +
ValidationContract

+ =
<

= >

TValidable

> H
>

H I
contract

J R
,

R S

Expression

T ^
<

^ _
Func

_ c
<

c d

TValidable

d n
,

n o
string

p v
>

v w
>

w x

expression	

y É
)


É Ñ
:


Ö Ü
base


á ã
(


ã å
contract


å î
,


î ï

expression


ñ †
)


† °
{


¢ £
}


§ •
public '
StringPropertyConfiguration *
<* +

TValidable+ 5
>5 6

IsRequired7 A
(A B
)B C
{ 	
return 

IsRequired 
( 
$str 5
)5 6
;6 7
} 	
public '
StringPropertyConfiguration *
<* +

TValidable+ 5
>5 6

IsRequired7 A
(A B
stringB H
messageI P
)P Q
{ 	
Contract 
. 
AddRule 
( 
new  
RequiredRule! -
<- .

TValidable. 8
,8 9
string: @
>@ A
(A B

ExpressionB L
,L M
messageN U
)U V
)V W
;W X
return 
this 
; 
} 	
public '
StringPropertyConfiguration *
<* +

TValidable+ 5
>5 6
HasMinLength7 C
(C D
intD G
	minLengthH Q
)Q R
{ 	
return 
HasMinLength 
(  
	minLength  )
,) *
$"+ -4
(Length must be greater than or equal to - U
{U V
	minLengthV _
}_ `
 characters` k
"k l
)l m
;m n
} 	
public '
StringPropertyConfiguration *
<* +

TValidable+ 5
>5 6
HasMinLength7 C
(C D
intD G
	minLengthH Q
,Q R
stringS Y
messageZ a
)a b
{ 	
Contract 
. 
AddRule 
( 
new  
MinLengthRule! .
<. /

TValidable/ 9
>9 :
(: ;

Expression; E
,E F
	minLengthG P
,P Q
messageR Y
)Y Z
)Z [
;[ \
return 
this 
; 
}   	
public"" '
StringPropertyConfiguration"" *
<""* +

TValidable""+ 5
>""5 6
HasMaxLength""7 C
(""C D
int""D G
	maxLength""H Q
)""Q R
{## 	
return$$ 
HasMaxLength$$ 
($$  
	maxLength$$  )
,$$) *
$"$$+ -1
%Length must be less than or equal to $$- R
{$$R S
	maxLength$$S \
}$$\ ]
 characters$$] h
"$$h i
)$$i j
;$$j k
}%% 	
public'' '
StringPropertyConfiguration'' *
<''* +

TValidable''+ 5
>''5 6
HasMaxLength''7 C
(''C D
int''D G
	maxLength''H Q
,''Q R
string''S Y
message''Z a
)''a b
{(( 	
Contract)) 
.)) 
AddRule)) 
()) 
new))  
MaxLengthRule))! .
<)). /

TValidable))/ 9
>))9 :
()): ;

Expression)); E
,))E F
	maxLength))G P
,))P Q
message))R Y
)))Y Z
)))Z [
;))[ \
return** 
this** 
;** 
}++ 	
public-- '
StringPropertyConfiguration-- *
<--* +

TValidable--+ 5
>--5 6

HasPattern--7 A
(--A B
string--B H
pattern--I P
)--P Q
{.. 	
return// 

HasPattern// 
(// 
pattern// %
,//% &
$str//' M
)//M N
;//N O
}00 	
public22 '
StringPropertyConfiguration22 *
<22* +

TValidable22+ 5
>225 6

HasPattern227 A
(22A B
string22B H
pattern22I P
,22P Q
string22R X
message22Y `
)22` a
{33 	
Contract44 
.44 
AddRule44 
(44 
new44  
PatternRule44! ,
<44, -

TValidable44- 7
>447 8
(448 9

Expression449 C
,44C D
pattern44E L
,44L M
message44N U
)44U V
)44V W
;44W X
return55 
this55 
;55 
}66 	
public88 '
StringPropertyConfiguration88 *
<88* +

TValidable88+ 5
>885 6
IsCpf887 <
(88< =
)88= >
{99 	
return:: 
IsCpf:: 
(:: 
$str:: 7
)::7 8
;::8 9
};; 	
public== '
StringPropertyConfiguration== *
<==* +

TValidable==+ 5
>==5 6
IsCpf==7 <
(==< =
string=== C
message==D K
)==K L
{>> 	
Contract?? 
.?? 
AddRule?? 
(?? 
new??  
CpfRule??! (
<??( )

TValidable??) 3
>??3 4
(??4 5

Expression??5 ?
,??? @
message??A H
)??H I
)??I J
;??J K
return@@ 
this@@ 
;@@ 
}AA 	
publicCC '
StringPropertyConfigurationCC *
<CC* +

TValidableCC+ 5
>CC5 6
IsCnpjCC7 =
(CC= >
)CC> ?
{DD 	
returnEE 
IsCnpjEE 
(EE 
$strEE 9
)EE9 :
;EE: ;
}FF 	
publicHH '
StringPropertyConfigurationHH *
<HH* +

TValidableHH+ 5
>HH5 6
IsCnpjHH7 =
(HH= >
stringHH> D
messageHHE L
)HHL M
{II 	
ContractJJ 
.JJ 
AddRuleJJ 
(JJ 
newJJ  
CnpjRuleJJ! )
<JJ) *

TValidableJJ* 4
>JJ4 5
(JJ5 6

ExpressionJJ6 @
,JJ@ A
messageJJB I
)JJI J
)JJJ K
;JJK L
returnKK 
thisKK 
;KK 
}LL 	
publicNN '
StringPropertyConfigurationNN *
<NN* +

TValidableNN+ 5
>NN5 6
HasRangeNN7 ?
(NN? @
intNN@ C
minNND G
,NNG H
intNNI L
maxNNM P
)NNP Q
{OO 	
returnPP 
HasRangePP 
(PP 
minPP 
,PP  
maxPP! $
,PP$ %
$"PP& (#
Length must be between PP( ?
{PP? @
minPP@ C
}PPC D
 and PPD I
{PPI J
maxPPJ M
}PPM N
 charactersPPN Y
"PPY Z
)PPZ [
;PP[ \
}QQ 	
publicSS '
StringPropertyConfigurationSS *
<SS* +

TValidableSS+ 5
>SS5 6
HasRangeSS7 ?
(SS? @
intSS@ C
minSSD G
,SSG H
intSSI L
maxSSM P
,SSP Q
stringSSR X
messageSSY `
)SS` a
{TT 	
ContractUU 
.UU 
AddRuleUU 
(UU 
newUU  
StringRangeRuleUU! 0
<UU0 1

TValidableUU1 ;
>UU; <
(UU< =

ExpressionUU= G
,UUG H
minUUI L
,UUL M
maxUUN Q
,UUQ R
messageUUS Z
)UUZ [
)UU[ \
;UU\ ]
returnVV 
thisVV 
;VV 
}WW 	
publicYY '
StringPropertyConfigurationYY *
<YY* +

TValidableYY+ 5
>YY5 6
IsEmailYY7 >
(YY> ?
)YY? @
{ZZ 	
return[[ 
IsEmail[[ 
([[ 
$str[[ B
)[[B C
;[[C D
}\\ 	
public^^ '
StringPropertyConfiguration^^ *
<^^* +

TValidable^^+ 5
>^^5 6
IsEmail^^7 >
(^^> ?
string^^? E
message^^F M
)^^M N
{__ 	
Contract`` 
.`` 
AddRule`` 
(`` 
new``  
	EmailRule``! *
<``* +

TValidable``+ 5
>``5 6
(``6 7

Expression``7 A
,``A B
message``C J
)``J K
)``K L
;``L M
returnaa 
thisaa 
;aa 
}bb 	
publicdd '
StringPropertyConfigurationdd *
<dd* +

TValidabledd+ 5
>dd5 6
	HasCustomdd7 @
(dd@ A
FuncddA E
<ddE F

TValidableddF P
,ddP Q
boolddR V
>ddV W
validateFuncddX d
)ddd e
{ee 	
returnff 
	HasCustomff 
(ff 
validateFuncff )
,ff) *
$strff+ T
)ffT U
;ffU V
}gg 	
publicii '
StringPropertyConfigurationii *
<ii* +

TValidableii+ 5
>ii5 6
	HasCustomii7 @
(ii@ A
FunciiA E
<iiE F

TValidableiiF P
,iiP Q
booliiR V
>iiV W
validateFunciiX d
,iid e
stringiif l
messageiim t
)iit u
{jj 	
Contractkk 
.kk 
AddRulekk 
(kk 
newkk  

CustomRulekk! +
<kk+ ,

TValidablekk, 6
>kk6 7
(kk7 8
validateFunckk8 D
,kkD E
messagekkF M
)kkM N
)kkN O
;kkO P
returnll 
thisll 
;ll 
}mm 	
publicoo '
StringPropertyConfigurationoo *
<oo* +

TValidableoo+ 5
>oo5 6
HasSpecificationoo7 G
(ooG H
ISpecificationooH V
<ooV W

TValidableooW a
>ooa b
specificationooc p
)oop q
{pp 	
returnqq 
HasSpecificationqq #
(qq# $
specificationqq$ 1
,qq1 2
nullqq3 7
)qq7 8
;qq8 9
}rr 	
publictt '
StringPropertyConfigurationtt *
<tt* +

TValidablett+ 5
>tt5 6
HasSpecificationtt7 G
(ttG H
ISpecificationttH V
<ttV W

TValidablettW a
>tta b
specificationttc p
,ttp q
stringttr x
message	tty Ä
)
ttÄ Å
{uu 	
Contractvv 
.vv 
AddRulevv 
(vv 
newvv  
SpecificationRulevv! 2
<vv2 3

TValidablevv3 =
>vv= >
(vv> ?
specificationvv? L
,vvL M
messagevvN U
)vvU V
)vvV W
;vvW X
returnww 
thisww 
;ww 
}xx 	
}yy 
}zz ˙3
TC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\EntityValidator.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

abstract 
class 
EntityValidator )
<) *
TEntity* 1
>1 2
:3 4
IEntityValidator5 E
<E F
TEntityF M
>M N
where	 
TEntity 
: 
class 
{ 
private		 $
IValidationContractCache		 (
cache		) .
;		. /
private 
Type 
contractType !
=" #
typeof$ *
(* +
ValidationContract+ =
<= >
>> ?
)? @
;@ A
private 
Type 

entityType 
=  !
typeof" (
(( )
TEntity) 0
)0 1
;1 2
public 
EntityValidator 
( 
)  
{ 	
cache 
= #
ValidationContractCache +
.+ ,
Current, 3
(3 4
)4 5
;5 6
} 	
public 
ValidationResult 
Validate  (
(( )
object) /
item0 4
)4 5
{ 	
Ensure 
. 
Argument 
. 
Is 
( 
item #
.# $
Is$ &
<& '
TEntity' .
>. /
(/ 0
)0 1
,1 2
$"3 5
{5 6
nameof6 <
(< =
item= A
)A B
}B C
 must be a C N
{N O
typeofO U
(U V
TEntityV ]
)] ^
.^ _
Name_ c
}c d
 type.d j
"j k
)k l
;l m
return 
Validate 
( 
( 
TEntity $
)$ %
item% )
)) *
;* +
} 	
public 
ValidationResult 
Validate  (
(( )
TEntity) 0
item1 5
)5 6
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
item$ (
,( )
nameof* 0
(0 1
item1 5
)5 6
)6 7
;7 8
var 
contract 
= 
cache  
.  !
GetOrAdd! )
() *
contractType* 6
,6 7

entityType8 B
,B C
CreateContractD R
)R S
;S T
var 
rulesResult 
= 
ValidateRules +
(+ ,
item, 0
,0 1
contract2 :
): ;
;; <
var 
includesResult 
=  
ValidateIncludes! 1
(1 2
item2 6
,6 7
contract8 @
)@ A
;A B
return!! 
rulesResult!! 
.!! 
Append!! %
(!!% &
includesResult!!& 4
)!!4 5
;!!5 6
}"" 	
	protected$$ 
abstract$$ 
void$$ 
	Configure$$  )
($$) *
ValidationContract$$* <
<$$< =
TEntity$$= D
>$$D E
contract$$F N
)$$N O
;$$O P
private&& 
ValidationContract&& "
CreateContract&&# 1
(&&1 2
Type&&2 6
contractType&&7 C
,&&C D
Type&&E I

entityType&&J T
)&&T U
{'' 	
var(( 
contract(( 
=(( 
new(( 
ValidationContract(( 1
<((1 2
TEntity((2 9
>((9 :
(((: ;
)((; <
;((< =
	Configure)) 
()) 
contract)) 
))) 
;))  
return++ 
contract++ 
;++ 
},, 	
private.. 
static.. 
ValidationResult.. '
ValidateRules..( 5
(..5 6
TEntity..6 =
item..> B
,..B C
ValidationContract..D V
contract..W _
).._ `
{// 	
var00 
result00 
=00 
new00 
ValidationResult00 -
(00- .
)00. /
;00/ 0
foreach22 
(22 
var22 
rule22 
in22  
contract22! )
.22) *
Rules22* /
)22/ 0
{33 
if44 
(44 
!44 
rule44 
.44 
Validate44 "
(44" #
item44# '
)44' (
)44( )
result55 
.55 
AddError55 #
(55# $
rule55$ (
.55( )
Property55) 1
,551 2
rule553 7
.557 8
Message558 ?
)55? @
;55@ A
}66 
return77 
result77 
;77 
}88 	
private:: 
ValidationResult::  
ValidateIncludes::! 1
(::1 2
TEntity::2 9
item::: >
,::> ?
ValidationContract::@ R
contract::S [
)::[ \
{;; 	
object<< 
entity<< 
;<< 
IEntityValidator== 
	validator== &
;==& '
var>> 
result>> 
=>> 
new>> 
ValidationResult>> -
(>>- .
)>>. /
;>>/ 0
foreach@@ 
(@@ 
var@@ 
include@@  
in@@! #
contract@@$ ,
.@@, -
Includes@@- 5
)@@5 6
{AA 
	validatorBB 
=BB 
includeBB #
.BB# $
KeyBB$ '
;BB' (
entityCC 
=CC 
includeCC  
.CC  !
ValueCC! &
.CC& '
CompileCC' .
(CC. /
)CC/ 0
.CC0 1
DynamicInvokeCC1 >
(CC> ?
itemCC? C
)CCC D
;CCD E
resultDD 
=DD 
resultDD 
.DD  
AppendDD  &
(DD& '
	validatorDD' 0
.DD0 1
ValidateDD1 9
(DD9 :
entityDD: @
)DD@ A
)DDA B
;DDB C
}EE 
returnGG 
resultGG 
;GG 
}HH 	
}II 
}JJ ”
UC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\IEntityValidator.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

	interface 
IEntityValidator %
{ 
ValidationResult 
Validate !
(! "
object" (
item) -
)- .
;. /
} 
} ˇ
VC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\IEntityValidator`.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

	interface 
IEntityValidator %
<% &
TEntity& -
>- .
:/ 0
IEntityValidator1 A
where 
TEntity 
: 
class 
{ 
ValidationResult 
Validate !
(! "
TEntity" )
item* .
). /
;/ 0
} 
} ⁄
]C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\IValidationContractCache.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

	interface $
IValidationContractCache -
{ 
ValidationContract 
GetOrAdd #
(# $
Type$ (
contractType) 5
,5 6
Type7 ;

entityType< F
,F G
FuncH L
<L M
TypeM Q
,Q R
TypeS W
,W X
ValidationContractY k
>k l
factorym t
)t u
;u v
} 
}		 ñ
TC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\IValidationRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

	interface 
IValidationRule $
{ 
string 
Property 
{ 
get 
; 
}  
string 
Message 
{ 
get 
; 
} 
bool 
Validate 
( 
object 
entity #
)# $
;$ %
}		 
}

 ã
UC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\IValidationRule`.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

	interface 
IValidationRule $
<$ %
in% '

TValidable( 2
>2 3
:4 5
IValidationRule6 E
whereF K

TValidableL V
:W X
classY ^
{ 
bool 
Validate 
( 

TValidable  
entity! '
)' (
;( )
} 
} †5
SC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\CnpjRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
CnpjRule  
<  !

TValidable! +
>+ ,
:- .
PropertyRule/ ;
<; <

TValidable< F
,F G
stringH N
>N O
whereP U

TValidableV `
:a b
classc h
{		 
public

 
CnpjRule

 
(

 

Expression

 "
<

" #
Func

# '
<

' (

TValidable

( 2
,

2 3
string

4 :
>

: ;
>

; <

expression

= G
)

G H
:

I J
this

K O
(

O P

expression

P Z
,

Z [
null

\ `
)

` a
{

b c
}

c d
public 
CnpjRule 
( 

Expression "
<" #
Func# '
<' (

TValidable( 2
,2 3
string4 :
>: ;
>; <

expression= G
,G H
stringI O
messageP W
)W X
:Y Z
base[ _
(_ `

expression` j
,j k
messagel s
)s t
{u v
}v w
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
cnpj 
= 
Compile !
(! "
entity" (
)( )
;) *
return 
ValidateCnpj 
(  
cnpj  $
)$ %
;% &
} 	
public 
bool 
ValidateCnpj  
(  !
string! '
cnpj( ,
), -
{ 	
int 
[ 
] 
multiplier1 
= 
new  #
int$ '
[' (
$num( *
]* +
{, -
$num. /
,/ 0
$num1 2
,2 3
$num4 5
,5 6
$num7 8
,8 9
$num: ;
,; <
$num= >
,> ?
$num@ A
,A B
$numC D
,D E
$numF G
,G H
$numI J
,J K
$numL M
,M N
$numO P
}Q R
;R S
int 
[ 
] 
multiplier2 
= 
new  #
int$ '
[' (
$num( *
]* +
{, -
$num. /
,/ 0
$num1 2
,2 3
$num4 5
,5 6
$num7 8
,8 9
$num: ;
,; <
$num= >
,> ?
$num@ A
,A B
$numC D
,D E
$numF G
,G H
$numI J
,J K
$numL M
,M N
$numO P
,P Q
$numR S
}T U
;U V
string 
tempCnpj 
, 
digit "
;" #
int 
sum 
, 
rest 
; 
var 
formatedCnpj 
= 
Regex $
.$ %
Replace% ,
(, -
cnpj- 1
,1 2
$str3 ;
,; <
$str= ?
)? @
;@ A
if 
( 
formatedCnpj 
. 
Length #
!=$ &
$num' )
||* ,
formatedCnpj- 9
.9 :
Distinct: B
(B C
)C D
.D E
CountE J
(J K
)K L
==M O
$numP Q
)Q R
return 
false 
; 
tempCnpj!! 
=!! 
formatedCnpj!! #
.!!# $
	Substring!!$ -
(!!- .
$num!!. /
,!!/ 0
$num!!1 3
)!!3 4
;!!4 5
sum"" 
="" 
$num"" 
;"" 
for$$ 
($$ 
int$$ 
i$$ 
=$$ 
$num$$ 
;$$ 
i$$ 
<$$ 
$num$$  "
;$$" #
i$$$ %
++$$% '
)$$' (
sum%% 
+=%% 
int%% 
.%% 
Parse%%  
(%%  !
tempCnpj%%! )
[%%) *
i%%* +
]%%+ ,
.%%, -
ToString%%- 5
(%%5 6
)%%6 7
)%%7 8
*%%9 :
multiplier1%%; F
[%%F G
i%%G H
]%%H I
;%%I J
rest'' 
='' 
('' 
sum'' 
%'' 
$num'' 
)'' 
;'' 
rest(( 
=(( 
rest(( 
<(( 
$num(( 
?(( 
$num(( 
:((  !
$num((" $
-((% &
rest((' +
;((+ ,
digit** 
=** 
rest** 
.** 
ToString** !
(**! "
)**" #
;**# $
tempCnpj++ 
=++ 
tempCnpj++ 
+++  !
digit++" '
;++' (
sum,, 
=,, 
$num,, 
;,, 
for.. 
(.. 
int.. 
i.. 
=.. 
$num.. 
;.. 
i.. 
<.. 
$num..  "
;.." #
i..$ %
++..% '
)..' (
sum// 
+=// 
int// 
.// 
Parse//  
(//  !
tempCnpj//! )
[//) *
i//* +
]//+ ,
.//, -
ToString//- 5
(//5 6
)//6 7
)//7 8
*//9 :
multiplier2//; F
[//F G
i//G H
]//H I
;//I J
rest11 
=11 
(11 
sum11 
%11 
$num11 
)11 
;11 
rest22 
=22 
rest22 
<22 
$num22 
?22 
$num22 
:22  !
$num22" $
-22% &
rest22' +
;22+ ,
digit44 
=44 
digit44 
+44 
rest44  
.44  !
ToString44! )
(44) *
)44* +
;44+ ,
return55 
formatedCnpj55 
.55  
EndsWith55  (
(55( )
digit55) .
)55. /
;55/ 0
}66 	
}77 
}88 å3
RC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\CpfRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
CpfRule 
<  

TValidable  *
>* +
:, -
PropertyRule. :
<: ;

TValidable; E
,E F
stringG M
>M N
whereO T

TValidableU _
:` a
classb g
{		 
public

 
CpfRule

 
(

 

Expression

 !
<

! "
Func

" &
<

& '

TValidable

' 1
,

1 2
string

3 9
>

9 :
>

: ;

expression

< F
)

F G
:

H I
this

J N
(

N O

expression

O Y
,

Y Z
null

[ _
)

_ `
{

a b
}

c d
public 
CpfRule 
( 

Expression !
<! "
Func" &
<& '

TValidable' 1
,1 2
string3 9
>9 :
>: ;

expression< F
,F G
stringH N
messageO V
)V W
:X Y
baseZ ^
(^ _

expression_ i
,i j
messagek r
)r s
{t u
}v w
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
cpf 
= 
Compile  
(  !
entity! '
)' (
;( )
return 
ValidateCpf 
( 
cpf "
)" #
;# $
} 	
public 
bool 
ValidateCpf 
(  
string  &
cpf' *
)* +
{ 	
int 
[ 
] 
multiplier1 
= 
new  #
int$ '
[' (
$num( )
]) *
{+ ,
$num- /
,/ 0
$num1 2
,2 3
$num4 5
,5 6
$num7 8
,8 9
$num: ;
,; <
$num= >
,> ?
$num@ A
,A B
$numC D
,D E
$numF G
}H I
;I J
int 
[ 
] 
multiplier2 
= 
new  #
int$ '
[' (
$num( *
]* +
{, -
$num. 0
,0 1
$num2 4
,4 5
$num6 7
,7 8
$num9 :
,: ;
$num< =
,= >
$num? @
,@ A
$numB C
,C D
$numE F
,F G
$numH I
,I J
$numK L
}M N
;N O
string 
tempCpf 
, 
digit !
;! "
int 
sum 
, 
rest 
; 
string 
formatedCpf 
=  
Regex! &
.& '
Replace' .
(. /
cpf/ 2
,2 3
$str4 <
,< =
$str> @
)@ A
;A B
if 
( 
formatedCpf 
. 
Length "
!=# %
$num& (
||) +
formatedCpf, 7
.7 8
Distinct8 @
(@ A
)A B
.B C
CountC H
(H I
)I J
==K M
$numN O
)O P
return 
false 
; 
tempCpf!! 
=!! 
formatedCpf!! !
.!!! "
	Substring!!" +
(!!+ ,
$num!!, -
,!!- .
$num!!/ 0
)!!0 1
;!!1 2
sum"" 
="" 
$num"" 
;"" 
for$$ 
($$ 
int$$ 
i$$ 
=$$ 
$num$$ 
;$$ 
i$$ 
<$$ 
$num$$  !
;$$! "
i$$# $
++$$$ &
)$$& '
sum%% 
+=%% 
int%% 
.%% 
Parse%%  
(%%  !
tempCpf%%! (
[%%( )
i%%) *
]%%* +
.%%+ ,
ToString%%, 4
(%%4 5
)%%5 6
)%%6 7
*%%8 9
multiplier1%%: E
[%%E F
i%%F G
]%%G H
;%%H I
rest'' 
='' 
sum'' 
%'' 
$num'' 
;'' 
rest(( 
=(( 
rest(( 
<(( 
$num(( 
?(( 
$num(( 
:((  !
$num((" $
-((% &
rest((' +
;((+ ,
digit** 
=** 
rest** 
.** 
ToString** !
(**! "
)**" #
;**# $
tempCpf++ 
=++ 
tempCpf++ 
+++ 
digit++  %
;++% &
sum,, 
=,, 
$num,, 
;,, 
for.. 
(.. 
int.. 
i.. 
=.. 
$num.. 
;.. 
i.. 
<.. 
$num..  "
;.." #
i..$ %
++..% '
)..' (
sum// 
+=// 
int// 
.// 
Parse//  
(//  !
tempCpf//! (
[//( )
i//) *
]//* +
.//+ ,
ToString//, 4
(//4 5
)//5 6
)//6 7
*//8 9
multiplier2//: E
[//E F
i//F G
]//G H
;//H I
rest11 
=11 
sum11 
%11 
$num11 
;11 
rest33 
=33 
rest33 
<33 
$num33 
?33 
$num33 
:33  !
$num33" $
-33% &
rest33' +
;33+ ,
digit44 
=44 
digit44 
+44 
rest44  
.44  !
ToString44! )
(44) *
)44* +
;44+ ,
return66 
formatedCpf66 
.66 
EndsWith66 '
(66' (
digit66( -
)66- .
;66. /
}77 	
}88 
}99 ê
UC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\CustomRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 

CustomRule "
<" #

TValidable# -
>- .
:/ 0
ValidationRule1 ?
<? @

TValidable@ J
>J K
whereL Q

TValidableR \
:] ^
class_ d
{ 
private 
readonly 
Func 
< 

TValidable (
,( )
bool* .
>. /
validateFunc0 <
;< =
public

 

CustomRule

 
(

 
Func

 
<

 

TValidable

 )
,

) *
bool

+ /
>

/ 0
validateFunc

1 =
)

= >
:

? @
this

A E
(

E F
validateFunc

F R
,

R S
null

T X
)

X Y
{

Z [
}

\ ]
public 

CustomRule 
( 
Func 
< 

TValidable )
,) *
bool+ /
>/ 0
validateFunc1 =
,= >
string? E
messageF M
)M N
:O P
baseQ U
(U V
messageV ]
)] ^
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
validateFunc$ 0
,0 1
nameof2 8
(8 9
validateFunc9 E
)E F
)F G
;G H
this 
. 
validateFunc 
= 
validateFunc  ,
;, -
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
return 
validateFunc 
(  
entity  &
)& '
;' (
} 	
} 
} á
TC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\EmailRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
	EmailRule !
<! "

TValidable" ,
>, -
:. /
PropertyRule0 <
<< =

TValidable= G
,G H
stringI O
>O P
whereQ V

TValidableW a
:b c
classd i
{ 
private		 
readonly		 
Regex		 
regex		 $
=		% &
new		' *
Regex		+ 0
(		0 1
$str		1 `
,		` a
RegexOptions		b n
.		n o
Compiled		o w
)		w x
;		x y
public 
	EmailRule 
( 

Expression #
<# $
Func$ (
<( )

TValidable) 3
,3 4
string5 ;
>; <
>< =

expression> H
)H I
:J K
thisL P
(P Q

expressionQ [
,[ \
null] a
)a b
{c d
}e f
public 
	EmailRule 
( 

Expression #
<# $
Func$ (
<( )

TValidable) 3
,3 4
string5 ;
>; <
>< =

expression> H
,H I
stringJ P
messageQ X
)X Y
:Z [
base\ `
(` a

expressiona k
,k l
messagem t
)t u
{v w
}x y
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
email 
= 
Compile "
(" #
entity# )
)) *
;* +
if 
( 
email 
. 
IsNullOrEmpty #
(# $
)$ %
)% &
return 
false 
; 
return 
regex 
. 
IsMatch  
(  !
email! &
)& '
;' (
} 	
} 
} ˚
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MaxCountRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MaxCountRule $
<$ %

TValidable% /
>/ 0
:1 2
PropertyRule3 ?
<? @

TValidable@ J
,J K
ICollectionL W
>W X
whereY ^

TValidable_ i
:j k
classl q
{ 
private		 
readonly		 
int		 
maxCount		 %
;		% &
public 
MaxCountRule 
( 

Expression &
<& '
Func' +
<+ ,

TValidable, 6
,6 7
ICollection8 C
>C D
>D E

expressionF P
,P Q
intR U
maxCountV ^
)^ _
:` a
thisb f
(f g

expressiong q
,q r
maxCounts {
,{ |
null	} Å
)
Å Ç
{
É Ñ
}
Ö Ü
public 
MaxCountRule 
( 

Expression &
<& '
Func' +
<+ ,

TValidable, 6
,6 7
ICollection8 C
>C D
>D E

expressionF P
,P Q
intR U
maxCountV ^
,^ _
string` f
messageg n
)n o
:p q
baser v
(v w

expression	w Å
,
Å Ç
message
É ä
)
ä ã
{ 	
this 
. 
maxCount 
= 
maxCount $
;$ %
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
ICollection 

collection "
=# $
Compile% ,
(, -
entity- 3
)3 4
;4 5
if 
( 

collection 
. 
IsNull !
(! "
)" #
)# $
return 
true 
; 
return 

collection 
. 
Count #
<=$ &
maxCount' /
;/ 0
} 	
} 
} Ê
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MaxLengthRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MaxLengthRule %
<% &

TValidable& 0
>0 1
:2 3
PropertyRule4 @
<@ A

TValidableA K
,K L
stringM S
>S T
whereU Z

TValidable[ e
:f g
classh m
{ 
private 
readonly 
int 
	maxLength &
;& '
public

 
MaxLengthRule

 
(

 

Expression

 '
<

' (
Func

( ,
<

, -

TValidable

- 7
,

7 8
string

9 ?
>

? @
>

@ A

expression

B L
,

L M
int

N Q
	maxLength

R [
)

[ \
:

] ^
this

_ c
(

c d

expression

d n
,

n o
	maxLength

p y
,

y z
null

{ 
)	

 Ä
{


Å Ç
}


É Ñ
public 
MaxLengthRule 
( 

Expression '
<' (
Func( ,
<, -

TValidable- 7
,7 8
string9 ?
>? @
>@ A

expressionB L
,L M
intN Q
	maxLengthR [
,[ \
string] c
messaged k
)k l
:m n
baseo s
(s t

expressiont ~
,~ 
message
Ä á
)
á à
{ 	
this 
. 
	maxLength 
= 
	maxLength &
;& '
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
value 
= 
Compile "
(" #
entity# )
)) *
;* +
if 
( 
value 
. 
IsNullOrEmpty #
(# $
)$ %
)% &
return 
true 
; 
return 
value 
. 
Length 
<=  "
	maxLength# ,
;, -
} 	
} 
} ﬂ
RC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MaxRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MaxRule 
<  

TValidable  *
,* +
TProp, 1
>1 2
:3 4
PropertyRule5 A
<A B

TValidableB L
,L M
TPropN S
>S T
whereU Z

TValidable[ e
:f g
classh m
wheren s
TPropt y
:z {
struct	| Ç
{ 
private		 
readonly		 
TProp		 
maxValue		 '
;		' (
public 
MaxRule 
( 

Expression !
<! "
Func" &
<& '

TValidable' 1
,1 2
TProp3 8
>8 9
>9 :

expression; E
,E F
TPropG L
maxValueM U
)U V
:W X
thisY ]
(] ^

expression^ h
,h i
maxValuej r
,r s
nullt x
)x y
{z {
}| }
public 
MaxRule 
( 

Expression !
<! "
Func" &
<& '

TValidable' 1
,1 2
TProp3 8
>8 9
>9 :

expression; E
,E F
TPropG L
maxValueM U
,U V
stringW ]
message^ e
)e f
:g h
basei m
(m n

expressionn x
,x y
message	z Å
)
Å Ç
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
maxValue$ ,
,, -
nameof. 4
(4 5
maxValue5 =
)= >
)> ?
;? @
this 
. 
maxValue 
= 
maxValue $
;$ %
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
TProp 
value 
= 
Compile !
(! "
entity" (
)( )
;) *
if 
( 
value 
is 
IComparable $
<$ %
TProp% *
>* +
genericComparable, =
)= >
return 
genericComparable (
.( )
	CompareTo) 2
(2 3
maxValue3 ;
); <
<== ?
$num@ A
;A B
if 
( 
value 
is 
IComparable $

comparable% /
)/ 0
return 

comparable !
.! "
	CompareTo" +
(+ ,
maxValue, 4
)4 5
<=6 8
$num9 :
;: ;
throw 
new 
ArgumentException '
(' (
$"( *
{* +
typeof+ 1
(1 2
TProp2 7
)7 8
.8 9
FullName9 A
}A B,
  does not implement IComparable.B b
"b c
)c d
;d e
} 	
} 
}   ∫
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MinCountRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MinCountRule $
<$ %

TValidable% /
>/ 0
:1 2
PropertyRule3 ?
<? @

TValidable@ J
,J K
ICollectionL W
>W X
whereY ^

TValidable_ i
:j k
classl q
{		 
private

 
readonly

 
int

 
minCount

 %
;

% &
public 
MinCountRule 
( 

Expression &
<& '
Func' +
<+ ,

TValidable, 6
,6 7
ICollection8 C
>C D
>D E

expressionF P
,P Q
intR U
minCountV ^
)^ _
:` a
thisb f
(f g

expressiong q
,q r
minCounts {
,{ |
null	} Å
)
Å Ç
{
É Ñ
}
Ö Ü
public 
MinCountRule 
( 

Expression &
<& '
Func' +
<+ ,

TValidable, 6
,6 7
ICollection8 C
>C D
>D E

expressionF P
,P Q
intR U
minCountV ^
,^ _
string` f
messageg n
)n o
:p q
baser v
(v w

expression	w Å
,
Å Ç
message
É ä
)
ä ã
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
minCount$ ,
,, -
nameof. 4
(4 5
minCount5 =
)= >
)> ?
;? @
this 
. 
minCount 
= 
minCount $
;$ %
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
ICollection 

collection "
=# $
Compile% ,
(, -
entity- 3
)3 4
;4 5
if 
( 

collection 
. 
IsNull !
(! "
)" #
&&$ &
minCount' /
>0 1
$num2 3
)3 4
return 
false 
; 
return 

collection 
. 
Count #
>=$ &
minCount' /
;/ 0
} 	
} 
} ®
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MinLengthRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MinLengthRule %
<% &

TValidable& 0
>0 1
:2 3
PropertyRule4 @
<@ A

TValidableA K
,K L
stringM S
>S T
whereU Z

TValidable[ e
:f g
classh m
{ 
private		 
readonly		 
int		 
	minLength		 &
;		& '
public 
MinLengthRule 
( 

Expression '
<' (
Func( ,
<, -

TValidable- 7
,7 8
string9 ?
>? @
>@ A

expressionB L
,L M
intN Q
	minLengthR [
)[ \
:] ^
this_ c
(c d

expressiond n
,n o
	minLengthp y
,y z
null{ 
)	 Ä
{
Å Ç
}
É Ñ
public 
MinLengthRule 
( 

Expression '
<' (
Func( ,
<, -

TValidable- 7
,7 8
string9 ?
>? @
>@ A

expressionB L
,L M
intN Q
	minLengthR [
,[ \
string] c
messaged k
)k l
:m n
baseo s
(s t

expressiont ~
,~ 
message
Ä á
)
á à
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
	minLength$ -
,- .
nameof/ 5
(5 6
	minLength6 ?
)? @
)@ A
;A B
this 
. 
	minLength 
= 
	minLength &
;& '
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
value 
= 
Compile "
(" #
entity# )
)) *
;* +
if 
( 
value 
. 
IsNullOrEmpty #
(# $
)$ %
&&& (
	minLength) 2
>3 4
$num5 6
)6 7
return 
false 
; 
return 
value 
. 
Length 
>=  "
	minLength# ,
;, -
} 	
} 
} ﬂ
RC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\MinRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
MinRule 
<  

TValidable  *
,* +
TProp, 1
>1 2
:3 4
PropertyRule5 A
<A B

TValidableB L
,L M
TPropN S
>S T
whereU Z

TValidable[ e
:f g
classh m
wheren s
TPropt y
:z {
struct	| Ç
{ 
private		 
readonly		 
TProp		 
minValue		 '
;		' (
public 
MinRule 
( 

Expression !
<! "
Func" &
<& '

TValidable' 1
,1 2
TProp3 8
>8 9
>9 :

expression; E
,E F
TPropG L
minValueM U
)U V
:W X
thisY ]
(] ^

expression^ h
,h i
minValuej r
,r s
nullt x
)x y
{z {
}| }
public 
MinRule 
( 

Expression !
<! "
Func" &
<& '

TValidable' 1
,1 2
TProp3 8
>8 9
>9 :

expression; E
,E F
TPropG L
minValueM U
,U V
stringW ]
message^ e
)e f
:g h
basei m
(m n

expressionn x
,x y
message	z Å
)
Å Ç
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
minValue$ ,
,, -
nameof. 4
(4 5
minValue5 =
)= >
)> ?
;? @
this 
. 
minValue 
= 
minValue $
;$ %
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
TProp 
value 
= 
Compile !
(! "
entity" (
)( )
;) *
if 
( 
value 
is 
IComparable $
<$ %
TProp% *
>* +
genericComparable, =
)= >
return 
genericComparable (
.( )
	CompareTo) 2
(2 3
minValue3 ;
); <
>== ?
$num@ A
;A B
if 
( 
value 
is 
IComparable $

comparable% /
)/ 0
return 

comparable !
.! "
	CompareTo" +
(+ ,
minValue, 4
)4 5
>=6 8
$num9 :
;: ;
throw 
new 
ArgumentException '
(' (
$"( *
{* +
typeof+ 1
(1 2
TProp2 7
)7 8
.8 9
FullName9 A
}A B,
  does not implement IComparable.B b
"b c
)c d
;d e
} 	
} 
}   Ï
VC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\PatternRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
PatternRule #
<# $

TValidable$ .
>. /
:0 1
PropertyRule2 >
<> ?

TValidable? I
,I J
stringK Q
>Q R
whereS X

TValidableY c
:d e
classf k
{		 
private

 
readonly

 
string

 
pattern

  '
;

' (
public 
PatternRule 
( 

Expression %
<% &
Func& *
<* +

TValidable+ 5
,5 6
string7 =
>= >
>> ?

expression@ J
,J K
stringL R
patternS Z
)Z [
:\ ]
this^ b
(b c

expressionc m
,m n
patterno v
,v w
nullx |
)| }
{~ 
}
Ä Å
public 
PatternRule 
( 

Expression %
<% &
Func& *
<* +

TValidable+ 5
,5 6
string7 =
>= >
>> ?

expression@ J
,J K
stringL R
patternS Z
,Z [
string\ b
messagec j
)j k
:l m
basen r
(r s

expressions }
,} ~
message	 Ü
)
Ü á
{ 	
Ensure 
. 
Argument 
. 
NotNullOrEmpty *
(* +
pattern+ 2
,2 3
nameof4 :
(: ;
pattern; B
)B C
)C D
;D E
this 
. 
pattern 
= 
pattern "
;" #
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
return 
Regex 
. 
IsMatch  
(  !
Compile! (
(( )
entity) /
)/ 0
,0 1
pattern2 9
)9 :
;: ;
} 	
} 
} Ø
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\PropertyRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

abstract 
class 
PropertyRule &
<& '

TValidable' 1
,1 2
TProp3 8
>8 9
:: ;
ValidationRule< J
<J K

TValidableK U
>U V
whereW \

TValidable] g
:h i
classj o
{ 
	protected		 

Expression		 
<		 
Func		 !
<		! "

TValidable		" ,
,		, -
TProp		. 3
>		3 4
>		4 5

Expression		6 @
{		A B
get		C F
;		F G
private		H O
set		P S
;		S T
}		U V
	protected 
PropertyRule 
( 

Expression )
<) *
Func* .
<. /

TValidable/ 9
,9 :
TProp; @
>@ A
>A B

expressionC M
)M N
:O P
thisQ U
(U V

expressionV `
,` a
nullb f
)f g
{h i
}j k
	protected 
PropertyRule 
( 

Expression )
<) *
Func* .
<. /

TValidable/ 9
,9 :
TProp; @
>@ A
>A B

expressionC M
,M N
stringO U
messageV ]
)] ^
:_ `
basea e
(e f

expressionf p
.p q
GetPropertyName	q Ä
(
Ä Å
)
Å Ç
,
Ç É
message
Ñ ã
)
ã å
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $

expression$ .
,. /
nameof0 6
(6 7

expression7 A
)A B
)B C
;C D

Expression 
= 

expression #
;# $
} 	
	protected 
TProp 
Compile 
(  

TValidable  *
entity+ 1
)1 2
{ 	
return 

Expression 
. 
Compile %
(% &
)& '
(' (
entity( .
). /
;/ 0
} 	
} 
} î
TC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\RangeRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
	RangeRule !
<! "

TValidable" ,
,, -
TProp. 3
>3 4
:5 6
PropertyRule7 C
<C D

TValidableD N
,N O
TPropP U
>U V
whereW \

TValidable] g
:h i
classj o
wherep u
TPropv {
:| }
struct	~ Ñ
{ 
private 
readonly 
TProp 
min "
;" #
private		 
readonly		 
TProp		 
max		 "
;		" #
public 
	RangeRule 
( 

Expression #
<# $
Func$ (
<( )

TValidable) 3
,3 4
TProp5 :
>: ;
>; <

expression= G
,G H
TPropI N
minO R
,R S
TPropT Y
maxZ ]
)] ^
:_ `
thisa e
(e f

expressionf p
,p q
minr u
,u v
maxw z
,z {
null	| Ä
)
Ä Å
{
Ç É
}
Ñ Ö
public 
	RangeRule 
( 

Expression #
<# $
Func$ (
<( )

TValidable) 3
,3 4
TProp5 :
>: ;
>; <

expression= G
,G H
TPropI N
minO R
,R S
TPropT Y
maxZ ]
,] ^
string_ e
messagef m
)m n
:o p
baseq u
(u v

expression	v Ä
,
Ä Å
message
Ç â
)
â ä
{ 	
this 
. 
min 
= 
min 
; 
this 
. 
max 
= 
max 
; 
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
MinRule 
< 

TValidable 
, 
TProp  %
>% &
minRule' .
=/ 0
new1 4
MinRule5 <
<< =

TValidable= G
,G H
TPropI N
>N O
(O P

ExpressionP Z
,Z [
min\ _
)_ `
;` a
MaxRule 
< 

TValidable 
, 
TProp  %
>% &
maxRule' .
=/ 0
new1 4
MaxRule5 <
<< =

TValidable= G
,G H
TPropI N
>N O
(O P

ExpressionP Z
,Z [
max\ _
)_ `
;` a
return 
minRule 
. 
Validate #
(# $
entity$ *
)* +
&&, .
maxRule/ 6
.6 7
Validate7 ?
(? @
entity@ F
)F G
;G H
} 	
} 
} £
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\RequiredRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
RequiredRule $
<$ %

TValidable% /
,/ 0
TProp1 6
>6 7
:8 9
PropertyRule: F
<F G

TValidableG Q
,Q R
TPropS X
>X Y
whereZ _

TValidable` j
:k l
classm r
{ 
public 
RequiredRule 
( 

Expression &
<& '
Func' +
<+ ,

TValidable, 6
,6 7
TProp8 =
>= >
>> ?

expression@ J
)J K
:L M
thisN R
(R S

expressionS ]
,] ^
null_ c
)c d
{e f
}g h
public

 
RequiredRule

 
(

 

Expression

 &
<

& '
Func

' +
<

+ ,

TValidable

, 6
,

6 7
TProp

8 =
>

= >
>

> ?

expression

@ J
,

J K
string

L R
message

S Z
)

Z [
:

\ ]
base

^ b
(

b c

expression

c m
,

m n
message

o v
)

v w
{

x y
}

z {
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
if 
( 
typeof 
( 
TProp 
) 
==  
typeof! '
(' (
string( .
). /
)/ 0
return 
! 
( 
Compile  
(  !
entity! '
)' (
as) +
string, 2
)2 3
.3 4
IsNullOrEmpty4 A
(A B
)B C
;C D
return 
Compile 
( 
entity !
)! "
!=# %
null& *
;* +
} 	
} 
} é
\C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\SpecificationRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
SpecificationRule )
<) *

TValidable* 4
>4 5
:6 7
ValidationRule8 F
<F G

TValidableG Q
>Q R
whereS X

TValidableY c
:d e
classf k
{ 
public 
ISpecification 
< 

TValidable (
>( )
Rule* .
{/ 0
get1 4
;4 5
private6 =
set> A
;A B
}C D
public

 
SpecificationRule

  
(

  !
ISpecification

! /
<

/ 0

TValidable

0 :
>

: ;
rule

< @
)

@ A
:

B C
this

D H
(

H I
rule

I M
,

M N
null

O S
)

S T
{

U V
}

W X
public 
SpecificationRule  
(  !
ISpecification! /
</ 0

TValidable0 :
>: ;
rule< @
,@ A
stringB H
messageI P
)P Q
:R S
baseT X
(X Y
messageY `
)` a
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
rule$ (
,( )
nameof* 0
(0 1
rule1 5
)5 6
)6 7
;7 8
Rule 
= 
rule 
; 
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
entity$ *
,* +
nameof, 2
(2 3
entity3 9
)9 :
,: ;
$str	< ê
)
ê ë
;
ë í
return 
Rule 
. 
IsSatisfiedBy %
(% &
entity& ,
), -
;- .
} 	
} 
} ≤
ZC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\Rules\StringRangeRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

sealed 
class 
StringRangeRule '
<' (

TValidable( 2
>2 3
:4 5
PropertyRule6 B
<B C

TValidableC M
,M N
stringO U
>U V
whereW \

TValidable] g
:h i
classj o
{ 
private 
readonly 
int 
min  
;  !
private		 
readonly		 
int		 
max		  
;		  !
public 
StringRangeRule 
( 

Expression )
<) *
Func* .
<. /

TValidable/ 9
,9 :
string; A
>A B
>B C

expressionD N
,N O
intP S
minT W
,W X
intY \
max] `
)` a
:b c
thisd h
(h i

expressioni s
,s t
minu x
,x y
maxz }
,} ~
null	 É
)
É Ñ
{
Ö Ü
}
á à
public 
StringRangeRule 
( 

Expression )
<) *
Func* .
<. /

TValidable/ 9
,9 :
string; A
>A B
>B C

expressionD N
,N O
intP S
minT W
,W X
intY \
max] `
,` a
stringb h
messagei p
)p q
:r s
baset x
(x y

expression	y É
,
É Ñ
message
Ö å
)
å ç
{ 	
this 
. 
min 
= 
min 
; 
this 
. 
max 
= 
max 
; 
} 	
public 
override 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
{ 	
string 
value 
= 
Compile "
(" #
entity# )
)) *
;* +
if 
( 
value 
. 
IsNullOrEmpty #
(# $
)$ %
&&& (
min) ,
>- .
$num/ 0
)0 1
return 
false 
; 
return 
value 
. 
Length 
<=  "
max# &
&&' )
value* /
./ 0
Length0 6
>=7 9
min: =
;= >
} 	
} 
} ±
WC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationContract.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

abstract 
class 
ValidationContract ,
{ 
	protected 
List 
< 
IValidationRule &
>& '
rules( -
;- .
	protected		 
List		 
<		 
KeyValuePair		 #
<		# $
IEntityValidator		$ 4
,		4 5
LambdaExpression		6 F
>		F G
>		G H
includes		I Q
;		Q R
public 
ValidationContract !
(! "
)" #
{ 	
rules 
= 
new 
List 
< 
IValidationRule ,
>, -
(- .
). /
;/ 0
includes 
= 
new 
List 
<  
KeyValuePair  ,
<, -
IEntityValidator- =
,= >
LambdaExpression? O
>O P
>P Q
(Q R
)R S
;S T
} 	
public 
IReadOnlyCollection "
<" #
IValidationRule# 2
>2 3
Rules4 9
{: ;
get< ?
{@ A
returnB H
rulesI N
;N O
}P Q
}R S
public 
IReadOnlyCollection "
<" #
KeyValuePair# /
</ 0
IEntityValidator0 @
,@ A
LambdaExpressionB R
>R S
>S T
IncludesU ]
=>^ `
includesa i
;i j
} 
} «,
\C:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationContractCache.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

class #
ValidationContractCache (
:) *$
IValidationContractCache+ C
{ 
private		 
static		 $
IValidationContractCache		 /
current		0 7
=		8 9
null		: >
;		> ?
private 
readonly  
ConcurrentDictionary -
<- .
CacheKey. 6
,6 7
ValidationContract8 J
>J K
cacheL Q
= 
new  
ConcurrentDictionary &
<& '
CacheKey' /
,/ 0
ValidationContract1 C
>C D
(D E
)E F
;F G
private #
ValidationContractCache '
(' (
)( )
{ 	
} 	
private 
readonly 
struct 
CacheKey  (
{ 	
public 
CacheKey 
( 
Type  
contractType! -
,- .
Type/ 3

entityType4 >
,> ?
Func@ D
<D E
TypeE I
,I J
TypeK O
,O P
ValidationContractQ c
>c d
factorye l
)l m
{ 
ContractType 
= 
contractType +
;+ ,

EntityType 
= 

entityType '
;' (
Factory 
= 
factory !
;! "
} 
public 
Type 
ContractType $
{% &
get' *
;* +
}, -
public 
Type 

EntityType "
{# $
get% (
;( )
}* +
public 
Func 
< 
Type 
, 
Type "
," #
ValidationContract$ 6
>6 7
Factory8 ?
{@ A
getB E
;E F
}G H
private!! 
bool!! 
Equals!! 
(!!  
CacheKey!!  (
other!!) .
)!!. /
=>"" 
ContractType"" 
.""  
Equals""  &
(""& '
other""' ,
."", -
ContractType""- 9
)""9 :
&&""; =

EntityType""> H
.""H I
Equals""I O
(""O P
other""P U
.""U V

EntityType""V `
)""` a
;""a b
public$$ 
override$$ 
bool$$  
Equals$$! '
($$' (
object$$( .
obj$$/ 2
)$$2 3
{%% 
if&& 
(&& 
obj&& 
.&& 
IsNull&& 
(&& 
)&&  
)&&  !
return'' 
false''  
;''  !
return)) 
obj)) 
.)) 
Is)) 
<)) 
CacheKey)) &
>))& '
())' (
)))( )
&&))* ,
Equals))- 3
())3 4
())4 5
CacheKey))5 =
)))= >
obj))> A
)))A B
;))B C
}** 
public,, 
override,, 
int,, 
GetHashCode,,  +
(,,+ ,
),,, -
{-- 
	unchecked.. 
{// 
return00 
(00 
ContractType00 (
.00( )
GetHashCode00) 4
(004 5
)005 6
*007 8
$num009 <
)00< =
^00> ?

EntityType00@ J
.00J K
GetHashCode00K V
(00V W
)00W X
;00X Y
}11 
}22 
}33 	
public55 
static55 $
IValidationContractCache55 .
Current55/ 6
(556 7
)557 8
=>559 ;
(55< =
current55= D
=55E F
current55G N
??55O Q
new55R U#
ValidationContractCache55V m
(55m n
)55n o
)55o p
;55p q
public77 
virtual77 
ValidationContract77 )
GetOrAdd77* 2
(772 3
Type773 7
contractType778 D
,77D E
Type77F J

entityType77K U
,77U V
Func77W [
<77[ \
Type77\ `
,77` a
Type77b f
,77f g
ValidationContract77h z
>77z {
factory	77| É
)
77É Ñ
{88 	
Ensure99 
.99 
NotNull99 
(99 
contractType99 '
,99' (
nameof99) /
(99/ 0

entityType990 :
)99: ;
)99; <
;99< =
Ensure:: 
.:: 
NotNull:: 
(:: 

entityType:: %
,::% &
nameof::' -
(::- .

entityType::. 8
)::8 9
)::9 :
;::: ;
return;; 
cache;; 
.;; 
GetOrAdd;; !
(;;! "
new;;" %
CacheKey;;& .
(;;. /
contractType;;/ ;
,;;; <

entityType;;= G
,;;G H
factory;;I P
);;P Q
,;;Q R
ck;;S U
=>;;V X
ck;;Y [
.;;[ \
Factory;;\ c
(;;c d
ck;;d f
.;;f g
ContractType;;g s
,;;s t
ck;;u w
.;;w x

EntityType	;;x Ç
)
;;Ç É
)
;;É Ñ
;
;;Ñ Ö
}<< 	
}== 
}>> ‡k
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationContract`.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{		 
public

 

sealed

 
class

 
ValidationContract

 *
<

* +

TValidable

+ 5
>

5 6
:

7 8
ValidationContract

9 K
where

L Q

TValidable

R \
:

] ^
class

_ d
{ 
public 
ValidationContract !
(! "
)" #
:$ %
base& *
(* +
)+ ,
{ 	
} 	
public '
ObjectPropertyConfiguration *
<* +

TValidable+ 5
,5 6
TProp7 <
>< =
Setup> C
<C D
TPropD I
>I J
(J K

ExpressionK U
<U V
FuncV Z
<Z [

TValidable[ e
,e f
TPropg l
>l m
>m n

expressiono y
)y z
where	{ Ä
TProp
Å Ü
:
á à
class
â é
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $

expression$ .
,. /
nameof0 6
(6 7

expression7 A
)A B
)B C
;C D
return 
new '
ObjectPropertyConfiguration 2
<2 3

TValidable3 =
,= >
TProp? D
>D E
(E F
thisF J
,J K

expressionL V
)V W
;W X
} 	
public +
CollectionPropertyConfiguration .
<. /

TValidable/ 9
>9 :
Setup; @
(@ A

ExpressionA K
<K L
FuncL P
<P Q

TValidableQ [
,[ \
ICollection] h
>h i
>i j

expressionk u
)u v
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $

expression$ .
,. /
nameof0 6
(6 7

expression7 A
)A B
)B C
;C D
return 
new +
CollectionPropertyConfiguration 6
<6 7

TValidable7 A
>A B
(B C
thisC G
,G H

expressionI S
)S T
;T U
} 	
public '
StringPropertyConfiguration *
<* +

TValidable+ 5
>5 6
Setup7 <
(< =

Expression= G
<G H
FuncH L
<L M

TValidableM W
,W X
stringY _
>_ `
>` a

expressionb l
)l m
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $

expression$ .
,. /
nameof0 6
(6 7

expression7 A
)A B
)B C
;C D
return 
new '
StringPropertyConfiguration 2
<2 3

TValidable3 =
>= >
(> ?
this? C
,C D

expressionE O
)O P
;P Q
}   	
public"" *
PrimitivePropertyConfiguration"" -
<""- .

TValidable"". 8
,""8 9
short"": ?
>""? @
Setup""A F
(""F G

Expression""G Q
<""Q R
Func""R V
<""V W

TValidable""W a
,""a b
short""c h
>""h i
>""i j

expression""k u
)""u v
{## 	
return$$ 
PropertyInner$$  
($$  !

expression$$! +
)$$+ ,
;$$, -
}%% 	
public'' *
PrimitivePropertyConfiguration'' -
<''- .

TValidable''. 8
,''8 9
int'': =
>''= >
Setup''? D
(''D E

Expression''E O
<''O P
Func''P T
<''T U

TValidable''U _
,''_ `
int''a d
>''d e
>''e f

expression''g q
)''q r
{(( 	
return)) 
PropertyInner))  
())  !

expression))! +
)))+ ,
;)), -
}** 	
public,, *
PrimitivePropertyConfiguration,, -
<,,- .

TValidable,,. 8
,,,8 9
long,,: >
>,,> ?
Setup,,@ E
(,,E F

Expression,,F P
<,,P Q
Func,,Q U
<,,U V

TValidable,,V `
,,,` a
long,,b f
>,,f g
>,,g h

expression,,i s
),,s t
{-- 	
return.. 
PropertyInner..  
(..  !

expression..! +
)..+ ,
;.., -
}// 	
public11 *
PrimitivePropertyConfiguration11 -
<11- .

TValidable11. 8
,118 9
ushort11: @
>11@ A
Setup11B G
(11G H

Expression11H R
<11R S
Func11S W
<11W X

TValidable11X b
,11b c
ushort11d j
>11j k
>11k l

expression11m w
)11w x
{22 	
return33 
PropertyInner33  
(33  !

expression33! +
)33+ ,
;33, -
}44 	
public66 *
PrimitivePropertyConfiguration66 -
<66- .

TValidable66. 8
,668 9
uint66: >
>66> ?
Setup66@ E
(66E F

Expression66F P
<66P Q
Func66Q U
<66U V

TValidable66V `
,66` a
uint66b f
>66f g
>66g h

expression66i s
)66s t
{77 	
return88 
PropertyInner88  
(88  !

expression88! +
)88+ ,
;88, -
}99 	
public;; *
PrimitivePropertyConfiguration;; -
<;;- .

TValidable;;. 8
,;;8 9
ulong;;: ?
>;;? @
Setup;;A F
(;;F G

Expression;;G Q
<;;Q R
Func;;R V
<;;V W

TValidable;;W a
,;;a b
ulong;;c h
>;;h i
>;;i j

expression;;k u
);;u v
{<< 	
return== 
PropertyInner==  
(==  !

expression==! +
)==+ ,
;==, -
}>> 	
public@@ *
PrimitivePropertyConfiguration@@ -
<@@- .

TValidable@@. 8
,@@8 9
byte@@: >
>@@> ?
Setup@@@ E
(@@E F

Expression@@F P
<@@P Q
Func@@Q U
<@@U V

TValidable@@V `
,@@` a
byte@@b f
>@@f g
>@@g h

expression@@i s
)@@s t
{AA 	
returnBB 
PropertyInnerBB  
(BB  !

expressionBB! +
)BB+ ,
;BB, -
}CC 	
publicEE *
PrimitivePropertyConfigurationEE -
<EE- .

TValidableEE. 8
,EE8 9
sbyteEE: ?
>EE? @
SetupEEA F
(EEF G

ExpressionEEG Q
<EEQ R
FuncEER V
<EEV W

TValidableEEW a
,EEa b
sbyteEEc h
>EEh i
>EEi j

expressionEEk u
)EEu v
{FF 	
returnGG 
PropertyInnerGG  
(GG  !

expressionGG! +
)GG+ ,
;GG, -
}HH 	
publicJJ *
PrimitivePropertyConfigurationJJ -
<JJ- .

TValidableJJ. 8
,JJ8 9
floatJJ: ?
>JJ? @
SetupJJA F
(JJF G

ExpressionJJG Q
<JJQ R
FuncJJR V
<JJV W

TValidableJJW a
,JJa b
floatJJc h
>JJh i
>JJi j

expressionJJk u
)JJu v
{KK 	
returnLL 
PropertyInnerLL  
(LL  !

expressionLL! +
)LL+ ,
;LL, -
}MM 	
publicOO *
PrimitivePropertyConfigurationOO -
<OO- .

TValidableOO. 8
,OO8 9
decimalOO: A
>OOA B
SetupOOC H
(OOH I

ExpressionOOI S
<OOS T
FuncOOT X
<OOX Y

TValidableOOY c
,OOc d
decimalOOe l
>OOl m
>OOm n

expressionOOo y
)OOy z
{PP 	
returnQQ 
PropertyInnerQQ  
(QQ  !

expressionQQ! +
)QQ+ ,
;QQ, -
}RR 	
publicTT *
PrimitivePropertyConfigurationTT -
<TT- .

TValidableTT. 8
,TT8 9
doubleTT: @
>TT@ A
SetupTTB G
(TTG H

ExpressionTTH R
<TTR S
FuncTTS W
<TTW X

TValidableTTX b
,TTb c
doubleTTd j
>TTj k
>TTk l

expressionTTm w
)TTw x
{UU 	
returnVV 
PropertyInnerVV  
(VV  !

expressionVV! +
)VV+ ,
;VV, -
}WW 	
publicYY *
PrimitivePropertyConfigurationYY -
<YY- .

TValidableYY. 8
,YY8 9
DateTimeYY: B
>YYB C
SetupYYD I
(YYI J

ExpressionYYJ T
<YYT U
FuncYYU Y
<YYY Z

TValidableYYZ d
,YYd e
DateTimeYYf n
>YYn o
>YYo p

expressionYYq {
)YY{ |
{ZZ 	
return[[ 
PropertyInner[[  
([[  !

expression[[! +
)[[+ ,
;[[, -
}\\ 	
public^^ 
void^^ 
Include^^ 
<^^ 
TProp^^ !
,^^! "
TEntityValidator^^# 3
>^^3 4
(^^4 5

Expression^^5 ?
<^^? @
Func^^@ D
<^^D E

TValidable^^E O
,^^O P
TProp^^Q V
>^^V W
>^^W X

expression^^Y c
)^^c d
where__ 
TProp__ 
:__ 
class__ 
where`` 
TEntityValidator`` "
:``# $
class``% *
,``* +
IEntityValidator``, <
<``< =
TProp``= B
>``B C
,``C D
new``E H
(``H I
)``I J
=>aa 
Includeaa 
(aa 

expressionaa !
,aa! "
newaa# &
TEntityValidatoraa' 7
(aa7 8
)aa8 9
)aa9 :
;aa: ;
publiccc 
voidcc 
Includecc 
<cc 
TPropcc !
>cc! "
(cc" #

Expressioncc# -
<cc- .
Funccc. 2
<cc2 3

TValidablecc3 =
,cc= >
TPropcc? D
>ccD E
>ccE F

expressionccG Q
,ccQ R
IEntityValidatorccS c
<ccc d
TPropccd i
>cci j
	validatorcck t
)cct u
wheredd 
TPropdd 
:dd 
classdd 
{ee 	
Ensureff 
.ff 
Argumentff 
.ff 
NotNullff #
(ff# $

expressionff$ .
,ff. /
nameofff0 6
(ff6 7

expressionff7 A
)ffA B
)ffB C
;ffC D
Ensuregg 
.gg 
Argumentgg 
.gg 
NotNullgg #
(gg# $
	validatorgg$ -
,gg- .
nameofgg/ 5
(gg5 6
	validatorgg6 ?
)gg? @
)gg@ A
;ggA B
includesii 
.ii 
Addii 
(ii 
newii 
KeyValuePairii )
<ii) *
IEntityValidatorii* :
,ii: ;
LambdaExpressionii< L
>iiL M
(iiM N
	validatoriiN W
,iiW X

expressioniiY c
)iic d
)iid e
;iie f
}jj 	
internalll 
voidll 
AddRulell 
(ll 
IValidationRulell -
<ll- .

TValidablell. 8
>ll8 9
rulell: >
)ll> ?
{mm 	
Ensurenn 
.nn 
Argumentnn 
.nn 
NotNullnn #
(nn# $
rulenn$ (
,nn( )
nameofnn* 0
(nn0 1
rulenn1 5
)nn5 6
)nn6 7
;nn7 8
rulesoo 
.oo 
Addoo 
(oo 
ruleoo 
)oo 
;oo 
}pp 	
privaterr *
PrimitivePropertyConfigurationrr .
<rr. /

TValidablerr/ 9
,rr9 :
TProprr; @
>rr@ A
PropertyInnerrrB O
<rrO P
TProprrP U
>rrU V
(rrV W

ExpressionrrW a
<rra b
Funcrrb f
<rrf g

TValidablerrg q
,rrq r
TProprrs x
>rrx y
>rry z

expression	rr{ Ö
)
rrÖ Ü
where
rrá å
TProp
rrç í
:
rrì î
struct
rrï õ
{ss 	
Ensurett 
.tt 
Argumenttt 
.tt 
NotNulltt #
(tt# $

expressiontt$ .
,tt. /
nameoftt0 6
(tt6 7

expressiontt7 A
)ttA B
)ttB C
;ttC D
returnuu 
newuu *
PrimitivePropertyConfigurationuu 5
<uu5 6

TValidableuu6 @
,uu@ A
TPropuuB G
>uuG H
(uuH I
thisuuI M
,uuM N

expressionuuO Y
)uuY Z
;uuZ [
}vv 	
}ww 
}xx “#
TC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationError.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

sealed 
class 
ValidationError '
:( )

IEquatable* 4
<4 5
ValidationError5 D
>D E
{ 
public 
string 
Property 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public		 
string		 
Message		 
{		 
get		  #
;		# $
private		% ,
set		- 0
;		0 1
}		2 3
internal 
ValidationError  
(  !
string! '
message( /
)/ 0
{ 	
Ensure 
. 
Argument 
. 
NotNullOrEmpty *
(* +
message+ 2
,2 3
nameof4 :
(: ;
message; B
)B C
)C D
;D E
Message 
= 
message 
; 
} 	
internal 
ValidationError  
(  !
string! '
property( 0
,0 1
string2 8
message9 @
)@ A
: 
this 
( 
message 
) 
{ 	
Property 
= 
property 
;  
} 	
public 
bool 
Equals 
( 
ValidationError *
other+ 0
)0 1
=>2 4
Equals5 ;
(; <
other< A
.A B
PropertyB J
,J K
PropertyL T
)T U
&&V X
EqualsY _
(_ `
other` e
.e f
Messagef m
,m n
Messageo v
)v w
;w x
public 
override 
string 
ToString '
(' (
)( )
{ 	
if 
( 
! 
Property 
. 
IsNullOrEmpty '
(' (
)( )
)) *
return 
$" 
{ 
Property "
}" #
: # %
{% &
Message& -
}- .
". /
;/ 0
return 
Message 
; 
} 	
public   
override   
bool   
Equals   #
(  # $
object  $ *
obj  + .
)  . /
{!! 	
if"" 
("" 
!"" 
obj"" 
."" 
Is"" 
<"" 
ValidationError"" '
>""' (
(""( )
)"") *
)""* +
return## 
false## 
;## 
return%% 
Equals%% 
(%% 
(%% 
ValidationError%% *
)%%* +
obj%%+ .
)%%. /
;%%/ 0
}&& 	
public(( 
override(( 
int(( 
GetHashCode(( '
(((' (
)((( )
{)) 	
	unchecked** 
{++ 
return,, 
(,, 
(,, 
Message,,  
.,,  !
GetHashCode,,! ,
(,,, -
),,- .
),,. /
*,,0 1
$num,,2 5
),,5 6
^,,7 8
Property,,9 A
?,,A B
.,,B C
GetHashCode,,C N
(,,N O
),,O P
??,,Q S
$num,,T U
;,,U V
}-- 
}.. 	
public00 
static00 
bool00 
operator00 #
==00$ &
(00& '
ValidationError00' 6
left007 ;
,00; <
ValidationError00= L
right00M R
)00R S
=>00T V
left00W [
.00[ \
Equals00\ b
(00b c
right00c h
)00h i
;00i j
public22 
static22 
bool22 
operator22 #
!=22$ &
(22& '
ValidationError22' 6
left227 ;
,22; <
ValidationError22= L
right22M R
)22R S
=>22T V
!22W X
left22X \
.22\ ]
Equals22] c
(22c d
right22d i
)22i j
;22j k
}33 
}44 Ë
XC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationExtensios.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

static 
class 
ValidationExtensios +
{ 
public		 
static		 
ValidationResult		 &
EnsureValid		' 2
(		2 3
this		3 7
ValidationResult		8 H
result		I O
)		O P
{

 	
Ensure 
. 
That 
< 
ValidationException +
>+ ,
(, -
result- 3
.3 4
IsValid4 ;
,; <
result= C
.C D
ErrorsD J
.J K
JoinK O
(O P
$strP T
)T U
)U V
;V W
return 
result 
; 
} 	
} 
} …
UC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationResult.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
{ 
public 

sealed 
class 
ValidationResult (
{ 
public		 
ValidationResult		 
(		  
params		  &
ValidationError		' 6
[		6 7
]		7 8
errors		9 ?
)		? @
:

 
this

 
(

 
errors

 
as

 
IEnumerable

 (
<

( )
ValidationError

) 8
>

8 9
)

9 :
{ 	
} 	
public 
ValidationResult 
(  
IEnumerable  +
<+ ,
ValidationError, ;
>; <
errors= C
)C D
{ 	
Errors 
= 
errors 
? 
. 
GroupBy 
( 
p 
=> 
new !
{" #
p$ %
.% &
Property& .
,. /
p0 1
.1 2
Message2 9
}: ;
); <
. 
Select 
( 
p 
=> 
p 
. 
First $
($ %
)% &
)& '
. 
ToList 
( 
) 
?? 
new 
List 
< 
ValidationError +
>+ ,
(, -
)- .
;. /
} 	
public 
bool 
IsValid 
=> 
Errors 
. 
Count 
== 
$num  
;  !
public 
ICollection 
< 
ValidationError *
>* +
Errors, 2
{3 4
get5 8
;8 9
}: ;
=< =
new> A
ListB F
<F G
ValidationErrorG V
>V W
(W X
)X Y
;Y Z
public 
void 
AddError 
( 
string #
message$ +
)+ ,
=> 
Errors 
. 
Add 
( 
new 
ValidationError -
(- .
message. 5
)5 6
)6 7
;7 8
public 
void 
AddError 
( 
string #
property$ ,
,, -
string. 4
message5 <
)< =
=>   
Errors   
.   
Add   
(   
new   
ValidationError   -
(  - .
property  . 6
,  6 7
message  8 ?
)  ? @
)  @ A
;  A B
internal"" 
ValidationResult"" !
Append""" (
(""( )
ValidationResult"") 9
appendResult"": F
)""F G
=>## 
new## 
ValidationResult## #
(### $
appendResult##$ 0
.##0 1
Errors##1 7
.##7 8
Union##8 =
(##= >
Errors##> D
)##D E
)##E F
;##F G
private%% 
void%% 
AddError%% 
(%% 
ValidationError%% -
error%%. 3
)%%3 4
=>&& 
Errors&& 
.&& 
Add&& 
(&& 
error&& 
)&&  
;&&  !
}'' 
}(( Ω
SC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\Validations\ValidationRule.cs
	namespace 	
Ritter
 
. 
Domain 
. 
Validations #
.# $
Rules$ )
{ 
public 

abstract 
class 
ValidationRule (
<( )

TValidable) 3
>3 4
:5 6
IValidationRule7 F
<F G

TValidableG Q
>Q R
whereS X

TValidableY c
:d e
classf k
{ 
	protected 
ValidationRule  
(  !
string! '
property( 0
,0 1
string2 8
message9 @
)@ A
:B C
thisD H
(H I
messageI P
)P Q
{		 	
Property

 
=

 
property

 
;

  
} 	
	protected 
ValidationRule  
(  !
string! '
message( /
)/ 0
{ 	
Message 
= 
message 
; 
} 	
public 
string 
Message 
{ 
get  #
;# $
	protected% .
set/ 2
;2 3
}4 5
public 
string 
Property 
{  
get! $
;$ %
	protected& /
set0 3
;3 4
}5 6
public 
abstract 
bool 
Validate %
(% &

TValidable& 0
entity1 7
)7 8
;8 9
public 
bool 
Validate 
( 
object #
entity$ *
)* +
{ 	
Ensure 
. 
That 
< %
InvalidOperationException 1
>1 2
(2 3
entity3 9
.9 :
Is: <
<< =

TValidable= G
>G H
(H I
)I J
,J K
$"L N5
)The entity object must be a instance of 'N w
{w x
typeofx ~
(~ 

TValidable	 â
)
â ä
.
ä ã
Name
ã è
}
è ê
'
ê ë
"
ë í
)
í ì
;
ì î
return 
Validate 
( 
( 

TValidable '
)' (
entity( .
). /
;/ 0
} 	
} 
} Ü,
DC:\Projects\anderson.souza\Ritter\src\Domain.Seedwork\ValueObject.cs
	namespace 	
Ritter
 
. 
Domain 
{ 
public 

class 
ValueObject 
{ 
	protected		 
ValueObject		 
(		 
)		 
{		  !
}		" #
public 
override 
bool 
Equals #
(# $
object$ *
obj+ .
). /
{ 	
if 
( 
obj 
. 
IsNull 
( 
) 
) 
return 
false 
; 
if 
( 
ReferenceEquals 
(  
this  $
,$ %
obj& )
)) *
)* +
return 
true 
; 
if 
( 
! 
this 
. 
GetType 
( 
) 
.  
IsInstanceOfType  0
(0 1
obj1 4
)4 5
)5 6
return 
false 
; 
PropertyInfo 
[ 
] 

properties %
=& '
this( ,
., -
GetType- 4
(4 5
)5 6
.6 7
GetProperties7 D
(D E
)E F
;F G
if 
( 

properties 
. 
Any 
( 
)  
)  !
{ 
return 

properties !
.! "
All" %
(% &
p& '
=>( *
{ 
var 
left 
= 
p  
.  !
GetValue! )
() *
this* .
,. /
null0 4
)4 5
;5 6
var 
right 
= 
p  !
.! "
GetValue" *
(* +
obj+ .
,. /
null0 4
)4 5
;5 6
return 
object !
.! "
Equals" (
(( )
left) -
,- .
right/ 4
)4 5
;5 6
}   
)   
;   
}!! 
return## 
true## 
;## 
}$$ 	
public&& 
override&& 
int&& 
GetHashCode&& '
(&&' (
)&&( )
{'' 	
int(( 
hashCode(( 
=(( 
$num(( 
;(( 
bool)) 
changeMultiplier)) !
=))" #
false))$ )
;))) *
int** 
index** 
=** 
$num** 
;** 
PropertyInfo,, 
[,, 
],, 

properties,, %
=,,& '
this,,( ,
.,,, -
GetType,,- 4
(,,4 5
),,5 6
.,,6 7
GetProperties,,7 D
(,,D E
),,E F
;,,F G
if.. 
(.. 

properties.. 
... 
Any.. 
(.. 
)..  
)..  !
{// 
foreach00 
(00 
var00 
item00 !
in00" $

properties00% /
)00/ 0
{11 
object22 
value22  
=22! "
item22# '
.22' (
GetValue22( 0
(220 1
this221 5
,225 6
null227 ;
)22; <
;22< =
if44 
(44 
value44 
.44 
IsNull44 $
(44$ %
)44% &
)44& '
hashCode55  
=55! "
hashCode55# +
^55, -
(55. /
index55/ 4
*555 6
$num557 9
)559 :
;55: ;
else66 
{77 
hashCode88  
=88! "
hashCode88# +
*88, -
(88. /
(88/ 0
changeMultiplier880 @
)88@ A
?88B C
$num88D F
:88G H
$num88I L
)88L M
+88N O
value88P U
.88U V
GetHashCode88V a
(88a b
)88b c
;88c d
changeMultiplier99 (
=99) *
!99+ ,
changeMultiplier99, <
;99< =
}:: 
};; 
}<< 
return>> 
Math>> 
.>> 
Abs>> 
(>> 
hashCode>> $
)>>$ %
;>>% &
}?? 	
publicAA 
staticAA 
boolAA 
operatorAA #
==AA$ &
(AA& '
ValueObjectAA' 2
leftAA3 7
,AA7 8
ValueObjectAA9 D
rightAAE J
)AAJ K
{BB 	
ifCC 
(CC 
leftCC 
.CC 
IsNullCC 
(CC 
)CC 
)CC 
returnDD 
rightDD 
.DD 
IsNullDD #
(DD# $
)DD$ %
;DD% &
returnFF 
leftFF 
.FF 
EqualsFF 
(FF 
rightFF $
)FF$ %
;FF% &
}GG 	
publicII 
staticII 
boolII 
operatorII #
!=II$ &
(II& '
ValueObjectII' 2
leftII3 7
,II7 8
ValueObjectII9 D
rightIIE J
)IIJ K
{JJ 	
returnKK 
!KK 
(KK 
leftKK 
==KK 
rightKK "
)KK" #
;KK# $
}LL 	
}MM 
}NN 