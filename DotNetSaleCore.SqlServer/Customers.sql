-- [5] 고객(Customers) 테이블: 회원 또는 비회원 중에서 물품을 구매한 사람
CREATE TABLE [dbo].[Customers]
(
	CustomerId INT identity(1,1) NOT NULL PRIMARY KEY,			-- 고객 고유번호 
	CustomerName nvarchar(50),			-- 고객명 
	EmailAddress nvarchar(50) null,		-- 이메일 
	
	[Address] nvarchar(100) null,		-- 주소
	AddressDetail nvarchar(100) null,	-- 상세주소 
	Phone1 nvarchar(4),					-- 전화번호1
	Phone2 nvarchar(4),					-- 전화번호2
	Phone3 nvarchar(4),					-- 전화번호3
	Mobile1 nvarchar(4),				-- 휴대폰1
	Mobile2 nvarchar(4),				-- 휴대폰2
	Mobile3 nvarchar(4),				-- 휴대폰3
	Zip nvarchar(255) null,				-- 우편번호 
	Ssn1 Char(6) null,					-- 주민번호1
	Ssn2 Char(7) null,					-- 주민번호2
	MemberDivision Int,					-- 멤버구분(0:비회원, 1:회원) 

	FirstName nvarchar(255) null,		-- 이름
	LastName nvarchar(255) null,		-- 성
	Gender nvarchar(255) null,			-- 성별 
	City nvarchar(255) null,			-- 도시 

	[CreatedBy] nvarchar(255) null,			-- 등록자
	[Created] datetime default(GetDate()),	-- 등록일 
	[ModifiedBy] nvarchar(255) null,		-- 수정자
	[Modified] datetime null,				-- 수정일 

)
go 