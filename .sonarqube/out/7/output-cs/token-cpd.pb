¡
aC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Emplopyees\Employee.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
	Employees+ 4
{		 
public

 

class

 
Employee

 
:

 
Entity

 "
{ 
public 

PersonName 
Name 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
string 
Cpf 
{ 
get 
;  
private! (
set) ,
;, -
}. /
	protected 
Employee 
( 
) 
: 
base #
(# $
)$ %
{& '
}( )
public 
Employee 
( 
string 
	firstName (
,( )
string* 0
lastName1 9
,9 :
string; A
cpfB E
)E F
:G H
thisI M
(M N
)N O
{ 	
Name 
= 
new 

PersonName !
(! "
	firstName" +
,+ ,
lastName- 5
)5 6
;6 7
	UpdateCpf 
( 
cpf 
) 
; 
} 	
public 
void 
	UpdateCpf 
( 
string $
cpf% (
)( )
{ 	
Ensure 
. 
That 
< 
ValidationException +
>+ ,
(, -
!- .
cpf. 1
.1 2
IsNullOrEmpty2 ?
(? @
)@ A
,A B
$strC Y
)Y Z
;Z [
Cpf 
= 
Regex 
. 
Replace 
(  
cpf  #
,# $
$str% -
,- .
$str/ 1
)1 2
;2 3
} 	
} 
}  
oC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Emplopyees\EmployeeRulesEvaluator.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
	Employees+ 4
{ 
public 

sealed 
class "
EmployeeRulesEvaluator .
:/ 0"
BusinessRulesEvaluator1 G
<G H
EmployeeH P
>P Q
{ 
public "
EmployeeRulesEvaluator %
(% &
)& '
{( )
}* +
} 
}		 ¦
jC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Emplopyees\EmployeeValidator.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
	Employees+ 4
{ 
public 

sealed 
class 
EmployeeValidator )
:* +
EntityValidator, ;
<; <
Employee< D
>D E
{ 
	protected 
override 
void 
	Configure  )
() *
ValidationContract* <
<< =
Employee= E
>E F
contractG O
)O P
{		 	
contract

 
.

 
Setup

 
(

 
e

 
=>

 
e

  !
.

! "
Cpf

" %
)

% &
. 

IsRequired 
( 
$str 1
)1 2
. 
HasMaxLength 
( 
$num  
)  !
. 

HasPattern 
( 
$str H
)H I
. 
IsCpf 
( 
) 
; 
contract 
. 
Include 
( 
p 
=> !
p" #
.# $
Name$ (
,( )
new* -
PersonNameValidator. A
(A B
)B C
)C D
;D E
} 	
} 
} ‹
lC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Emplopyees\IEmployeeRepository.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
	Employees+ 4
{ 
public 

	interface 
IEmployeeRepository (
:) *
IRepository+ 6
<6 7
Employee7 ?
>? @
{ 
} 
} É
`C:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Persons\PersonName.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
Persons+ 2
{ 
public 

class 

PersonName 
: 
ValueObject )
{		 
public

 
string

 
	FirstName

 
{

  !
get

" %
;

% &
private

' .
set

/ 2
;

2 3
}

4 5
public 
string 
LastName 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
	protected 

PersonName 
( 
) 
:  
base! %
(% &
)& '
{( )
}* +
public 

PersonName 
( 
string  
	firstName! *
,* +
string, 2
lastName3 ;
); <
:= >
this? C
(C D
)D E
{ 	
Ensure 
. 
That 
< 
ValidationException +
>+ ,
(, -
!- .
	firstName. 7
.7 8
IsNullOrEmpty8 E
(E F
)F G
,G H
$strI f
)f g
;g h
Ensure 
. 
That 
< 
ValidationException +
>+ ,
(, -
!- .
lastName. 6
.6 7
IsNullOrEmpty7 D
(D E
)E F
,F G
$strH d
)d e
;e f
	FirstName 
= 
	firstName !
;! "
LastName 
= 
lastName 
;  
} 	
} 
} Ç
iC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.Domain\Aggregates\Persons\PersonNameValidator.cs
	namespace 	
Ritter
 
. 
Samples 
. 
Domain 
.  

Aggregates  *
.* +
Persons+ 2
{ 
public 

sealed 
class 
PersonNameValidator +
:, -
EntityValidator. =
<= >

PersonName> H
>H I
{ 
	protected 
override 
void 
	Configure  )
() *
ValidationContract* <
<< =

PersonName= G
>G H
contractI Q
)Q R
{ 	
contract		 
.		 
Setup		 
(		 
e		 
=>		 
e		  !
.		! "
	FirstName		" +
)		+ ,
.

 

IsRequired

 
(

 
)

 
. 
HasMaxLength 
( 
$num  
)  !
;! "
contract 
. 
Setup 
( 
e 
=> 
e  !
.! "
LastName" *
)* +
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
} 	
} 
} 