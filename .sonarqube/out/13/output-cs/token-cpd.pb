—
SC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.IoC\RegistrationBuilder.cs
	namespace 	
Ritter
 
. 
Samples 
. 
IoC 
{ 
public		 

class		 
RegistrationBuilder		 $
{

 
public 
RegistrationBuilder "
(" #
Assembly# +
assembly, 4
)4 5
{ 	
Ensure 
. 
Argument 
. 
NotNull #
(# $
assembly$ ,
,, -
nameof. 4
(4 5
assembly5 =
)= >
)> ?
;? @
Assembly 
= 
assembly 
;  
} 	
public 
Assembly 
Assembly  
{! "
get# &
;& '
}( )
public 
RegistrationBuilder "
AddAll# )
<) *
TService* 2
>2 3
(3 4
Action4 :
<: ;
Type; ?
,? @
TypeA E
>E F
registrationActionG Y
)Y Z
where 
TService 
: 
class "
{ 	
Type 
serviceType 
= 
typeof %
(% &
TService& .
). /
;/ 0
ConfigureTypes 
( 
serviceType &
,& '
Assembly( 0
,0 1
registrationAction2 D
)D E
;E F
return 
this 
; 
} 	
private 
static 
void 
ConfigureTypes *
(* +
Type+ /
serviceType0 ;
,; <
Assembly= E
assemblyF N
,N O
ActionP V
<V W
TypeW [
,[ \
Type] a
>a b
registrationActionc u
)u v
{ 	
assembly 
. 
GetTypes 
( 
) 
. 
Where 
( 
type 
=> 
type #
.# $
IsClass$ +
&&, .
!/ 0
type0 4
.4 5

IsAbstract5 ?
&&@ B
serviceTypeC N
.N O
IsAssignableFromO _
(_ `
type` d
)d e
)e f
.   
Select   
(   
type   
=>   
new    #
{  $ %
Service  & -
=  . /
type  0 4
.  4 5
GetInterfaces  5 B
(  B C
)  C D
.  D E
Last  E I
(  I J
)  J K
,  K L
Implementation  M [
=  \ ]
type  ^ b
}  c d
)  d e
.!! 
ForEach!! 
(!! 
registration!! %
=>!!& (
registrationAction!!) ;
?!!; <
.!!< =
Invoke!!= C
(!!C D
registration!!D P
.!!P Q
Service!!Q X
,!!X Y
registration!!Z f
.!!f g
Implementation!!g u
)!!u v
)!!v w
;!!w x
}"" 	
}## 
}$$ ú
SC:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.IoC\RegistrationOptions.cs
	namespace 	
Ritter
 
. 
Samples 
. 
IoC 
{ 
public 

sealed 
class 
RegistrationOptions +
{ 
public 
string 
ConnectionString &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ×#
[C:\Projects\anderson.souza\Ritter\samples\Ritter.Samples.IoC\ServiceCollectionExtensions.cs
	namespace

 	
	Microsoft


 
.

 

Extensions

 
.

 
DependencyInjection

 2
{ 
public 

static 
class '
ServiceCollectionExtensions 3
{ 
public 
static 
IServiceCollection (
AddDependencies) 8
(8 9
this9 =
IServiceCollection> P
servicesQ Y
,Y Z
string[ a
connectionStringb r
)r s
{ 	
void 
optionsBuilder 
(  #
DbContextOptionsBuilder  7
options8 ?
)? @
{ 
options 
. 
UseSqlServer $
($ %
connectionString% 5
)5 6
;6 7
options 
. &
EnableSensitiveDataLogging 2
(2 3
)3 4
;4 5
} 
services 
. '
AddEntityFrameworkSqlServer 0
(0 1
)1 2
.2 3
AddDbContext3 ?
<? @

UnitOfWork@ J
>J K
(K L
optionsBuilderL Z
,Z [
ServiceLifetime\ k
.k l
	Transientl u
)u v
;v w
services 
. 
AddTransient !
<! " 
IQueryableUnitOfWork" 6
>6 7
(7 8
provider8 @
=>A C
providerD L
.L M

GetServiceM W
<W X

UnitOfWorkX b
>b c
(c d
)d e
)e f
;f g
services 
. 
FromAssembly !
<! "
EmployeeRepository" 4
>4 5
(5 6
)6 7
.7 8
AddAll8 >
<> ?
IRepository? J
>J K
(K L
(L M
serviceM T
,T U
implementationV d
)d e
=> 
services 
. 
AddTransient (
(( )
service) 0
,0 1
implementation2 @
)@ A
)A B
;B C
services 
. 
FromAssembly !
<! "
EmployeeAppService" 4
>4 5
(5 6
)6 7
.7 8
AddAll8 >
<> ?
IAppService? J
>J K
(K L
(L M
serviceM T
,T U
implementationV d
)d e
=> 
services 
. 
AddTransient (
(( )
service) 0
,0 1
implementation2 @
)@ A
)A B
;B C
return 
services 
; 
} 	
private!! 
static!! 
RegistrationBuilder!! *
FromAssembly!!+ 7
<!!7 8
TServiceSource!!8 F
>!!F G
(!!G H
this!!H L
IServiceCollection!!M _
services!!` h
)!!h i
where"" 
TServiceSource""  
:""! "
class""# (
{## 	
return$$ 
new$$ 
RegistrationBuilder$$ *
($$* +
typeof$$+ 1
($$1 2
TServiceSource$$2 @
)$$@ A
.$$A B
Assembly$$B J
)$$J K
;$$K L
}%% 	
private'' 
static'' 
RegistrationBuilder'' *
AddAll''+ 1
<''1 2
TService''2 :
>'': ;
(''; <
this''< @
IServiceCollection''A S
services''T \
,''\ ]
Action''^ d
<''d e
Type''e i
,''i j
Type''k o
>''o p
registrationAction	''q ƒ
)
''ƒ „
where(( 
TService(( 
:(( 
class(( 
{)) 	
RegistrationBuilder** 
builder**  '
=**( )
new*** -
RegistrationBuilder**. A
(**A B
typeof**B H
(**H I
TService**I Q
)**Q R
.**R S
Assembly**S [
)**[ \
;**\ ]
return++ 
builder++ 
.++ 
AddAll++ !
<++! "
TService++" *
>++* +
(+++ ,
registrationAction++, >
)++> ?
;++? @
},, 	
}-- 
}.. 