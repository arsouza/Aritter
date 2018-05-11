´
JC:\Projects\anderson.souza\Ritter\src\Infra.Http.Seedwork\ApiController.cs
	namespace 	
Ritter
 
. 
Infra 
. 
Http 
{ 
public 

abstract 
class 
ApiController '
:( )

Controller* 4
{ 
[ 	
	NonAction	 
] 
public		 
virtual		 
ObjectResult		 #
OkOrNotFound		$ 0
(		0 1
object		1 7
value		8 =
)		= >
{

 	
if 
( 
value 
. 
IsNull 
( 
) 
) 
return 
NotFound 
(  
value  %
)% &
;& '
return 
Ok 
( 
value 
) 
; 
} 	
} 
} Þ
zC:\Projects\anderson.souza\Ritter\src\Infra.Http.Seedwork\Extensions\TypeAdapter\TypeAdapterServiceCollectionExtensions.cs
	namespace 	
	Microsoft
 
. 

Extensions 
. 
DependencyInjection 2
{ 
public 

static 
class 2
&TypeAdapterServiceCollectionExtensions >
{ 
public 
static 
IServiceCollection (
AddTypeAdapter) 7
(7 8
this8 <
IServiceCollection= O
servicesP X
,X Y
ITypeAdapterZ f
typeAdapterFactoryg y
)y z
{		 	
Ensure

 
.

 
Argument

 
.

 
NotNull

 #
(

# $
typeAdapterFactory

$ 6
,

6 7
nameof

8 >
(

> ?
typeAdapterFactory

? Q
)

Q R
)

R S
;

S T
services 
. 
AddSingleton !
(! "
typeof" (
(( )
ITypeAdapter) 5
)5 6
,6 7
typeAdapterFactory8 J
)J K
;K L
return 
services 
; 
} 	
public 
static 
IServiceCollection (
AddTypeAdapter) 7
<7 8
TTypeAdapter8 D
>D E
(E F
thisF J
IServiceCollectionK ]
services^ f
)f g
where 
TTypeAdapter 
:  
class! &
,& '
ITypeAdapter( 4
,4 5
new6 9
(9 :
): ;
{ 	
services 
. 
AddSingleton !
<! "
ITypeAdapter" .
,. /
TTypeAdapter0 <
>< =
(= >
)> ?
;? @
return 
services 
; 
} 	
} 
} Ç
]C:\Projects\anderson.souza\Ritter\src\Infra.Http.Seedwork\Filters\HttpErrorFilterAttribute.cs
	namespace 	
Ritter
 
. 
Infra 
. 
Http 
. 
Filters #
{ 
public 

class $
HttpErrorFilterAttribute )
:* +$
ExceptionFilterAttribute, D
{		 
public

 
override

 
void

 
OnException

 (
(

( )
ExceptionContext

) 9
context

: A
)

A B
{ 	
if 
( 
context 
. 
	Exception !
.! "
Is" $
<$ %
ValidationException% 8
>8 9
(9 :
): ;
); <
{ 
context 
. 
Result 
=  
new! $"
BadRequestObjectResult% ;
(; <
context< C
.C D
	ExceptionD M
.M N
MessageN U
)U V
;V W
return 
; 
} 
if 
( 
context 
. 
	Exception !
.! "
Is" $
<$ %#
NotFoundObjectException% <
>< =
(= >
)> ?
)? @
{ 
context 
. 
Result 
=  
new! $ 
NotFoundObjectResult% 9
(9 :
context: A
.A B
	ExceptionB K
.K L
MessageL S
)S T
;T U
return 
; 
} 
base 
. 
OnException 
( 
context $
)$ %
;% &
} 	
} 
} 