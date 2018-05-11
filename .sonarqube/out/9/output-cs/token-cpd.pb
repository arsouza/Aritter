Î
PC:\Projects\anderson.souza\Ritter\src\Application.Seedwork\Models\PagedResult.cs
	namespace 	
Ritter
 
. 
Application 
. 
Models #
{ 
public 

static 
class 
PagedResult #
{ 
public 
static 
PagedResult !
<! "
TItem" '
>' (
FromList) 1
<1 2
TItem2 7
>7 8
(8 9
ICollection9 D
<D E
TItemE J
>J K
listL P
,P Q
intR U
	pageCountV _
,_ `
inta d

totalCounte o
)o p
=> 
new 
PagedResult 
< 
TItem $
>$ %
(% &
list& *
,* +
	pageCount, 5
,5 6

totalCount7 A
)A B
;B C
}		 
}

 ç
QC:\Projects\anderson.souza\Ritter\src\Application.Seedwork\Models\PagedResult`.cs
	namespace 	
Ritter
 
. 
Application 
. 
Models #
{ 
public 

sealed 
class 
PagedResult #
<# $
T$ %
>% &
{ 
public 
PagedResult 
( 
ICollection &
<& '
T' (
>( )
page* .
,. /
int0 3
	pageCount4 =
,= >
int? B

totalCountC M
)M N
{ 	

TotalCount		 
=		 

totalCount		 #
;		# $
	PageCount

 
=

 
	pageCount

 !
;

! "
Items 
= 
page 
; 
} 	
public 
int 

TotalCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
	PageCount 
{ 
get "
;" #
set$ '
;' (
}) *
public 
IEnumerable 
< 
T 
> 
Items #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} ñ

QC:\Projects\anderson.souza\Ritter\src\Application.Seedwork\Models\PagingFilter.cs
	namespace 	
Ritter
 
. 
Application 
. 
Models #
{ 
public 

sealed 
class 
PagingFilter $
{ 
public

 
int

 
	PageIndex

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
int 
PageSize 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
OrderByName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
bool 
	Ascending 
{ 
get  #
;# $
set% (
;( )
}* +
public 

Pagination 
GetPagination '
(' (
)( )
=>* ,
new- 0

Pagination1 ;
(; <
	PageIndex< E
,E F
PageSizeG O
,O P
OrderByNameQ \
,\ ]
	Ascending^ g
)g h
;h i
} 
} ﬁ
QC:\Projects\anderson.souza\Ritter\src\Application.Seedwork\Services\AppService.cs
	namespace 	
Ritter
 
. 
Application 
. 
Services %
{ 
public 

abstract 
class 

AppService $
:% &
IAppService' 2
{ 
	protected 
readonly 
ILogger "
logger# )
;) *
	protected		 

AppService		 
(		 
ILogger		 $
logger		% +
)		+ ,
{

 	
this 
. 
logger 
= 
logger  
;  !
} 	
} 
} ∆
RC:\Projects\anderson.souza\Ritter\src\Application.Seedwork\Services\IAppService.cs
	namespace 	
Ritter
 
. 
Application 
. 
Services %
{ 
public 

	interface 
IAppService  
{ 
} 
} 