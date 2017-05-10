/*Procedura na odstranìní hráèe ze seznamu zablokovaných...*/
ALTER procedure ExpiredBan
as
begin
Declare @date DATETIME;
set @date = CONVERT (date, GETDATE());
 DELETE FROM Hala_propadliku WHERE doba_zablokovani = @date;
end

create procedure ChangeNameRank @oldName VARCHAR(30), @newName VARCHAR(30)
as
begin
IF(EXISTS(SELECT nazev FROM "rank" where nazev = @newName))
 begin
  print('Hráè se jménem: '+@newName+' existuje');
 end 
  else
   begin
    UPDATE "rank" set nazev = @newName where nazev=@oldName
   end
end


/*Zmìnení ranku*/
ALTER procedure RankUp
AS
--DHCursor detail hráèe
 DECLARE DHCursor CURSOR FOR SELECT Detail_Hrace.Skore FROM Detail_Hrace 
BEGIN
--Deklarace pro Detail hrace
 Declare @dhSkore INT;
 Open DHCursor
   FETCH NEXT FROM DHCursor INTO @dhSkore;
   WHILE @@FETCH_STATUS = 0
    BEGIN
	 if(@dhSkore<=150)
	  BEGIN
	   Begin tran
	    begin try
	     UPDATE Detail_Hrace SET rID = 1 where Detail_Hrace.Skore<=150;
		 print('OK');
		 commit;
		end try
		Begin CATCH
		   print('Chyba');
		   ROLLBACK
	    END CATCH
	  END
	  ELSE IF(@dhSkore>=151 AND @dhSkore<=200)
	   begin
	    Begin tran
	     begin try
	      UPDATE Detail_Hrace SET rID = 2 where Detail_Hrace.Skore>=151 AND Detail_Hrace.Skore<=200;
		  print('OK');
		  commit;
		 end try
		 Begin CATCH
		  print('Chyba');
		  ROLLBACK
		 END CATCH
	   end
	  ELSE IF(@dhSkore>=201 AND @dhSkore<=450)
	   BEGIN
	    Begin tran
	     begin try
	      UPDATE Detail_Hrace SET rID = 3 where Detail_Hrace.Skore>=201 AND Detail_Hrace.Skore<=450;
		  print('OK');
		  commit;
		 end try
		 Begin CATCH
		  print('Chyba');
		  ROLLBACK
		 END CATCH
	   END
	  ELSE IF(@dhSkore>=451 AND @dhSkore<=1000)
	   BEGIN
	    Begin tran
	     begin try
	      UPDATE Detail_Hrace SET rID = 4 where Detail_Hrace.Skore>=451 AND Detail_Hrace.Skore<=1000;
		  print('OK');
		  commit;
		 end try
		 Begin CATCH
		  print('Chyba');
		  ROLLBACK
		 END CATCH
	    END

	   FETCH NEXT FROM DHCursor INTO @dhSkore
	  print('Aktualizace uzivatelu probehla v poradku');
	  END
   close DHCursor;
 DEALLOCATE DHCursor;
END

/*Pridání hráèe do týmu*/
alter procedure JoinToTeam @nameOfPlayer VARCHAR(30),@nameOfTeam Varchar(30)
as
BEGIN
if EXISTS(
 select nick_name from Hrac h
 JOIN TymHrac th on th.Hrac_hID=h.hID
 JOIN Tym t on t.tID = th.Tym_tID and h.Nick_name=@nameOfPlayer
)
 BEGIN
  Print('Uzivatel jiz v tymu existuje');
 END
else
 Begin
  INSERT INTO tymHrac VALUES((SELECT hID from hrac where hrac.Nick_name=@nameOfPlayer),(SELECT tID from tym where tym.Nazev_tymu=@nameOfTeam));
  Print('uzivatel byl pridan do tymu');
 END
eND


/*Registrace*/

alter procedure AddPlayer @Name VARCHAR(50), @pass VARCHAR(128), @Email Varchar(50)
as
 begin
 Declare @id VARCHAR(1000);
 Declare @datum DATE;
 set @datum = SYSDATETIME();
 IF EXISTS(SELECT nick_name from Hrac where Nick_name=@Name)
   begin

    print('Hrac se jmenem: '+@Name+' existuje');
   end
  else
   begin
    Begin try
     Begin tran
      INSERT INTO HRAC (Nick_name) VALUES(@Name);
	  set @id = (SELECT top 1 hID from Hrac order by hID desc);
      INSERT INTO Detail_Hrace (rID,hID,p_Her,p_Vyher,Skore,Pozice) Values(1,@id,0,0,150,0);
	  INSERT INTO Nastaveni_Hrace (hID,Jmeno,Prijmeni,Heslo,Email,Lokace,datum_reg) VALUES(@id,NULL,NULL,@pass,@Email,NULL,@datum);
	  Print('Uživatel registrován');
	 commit
	 end try
	  Begin Catch
	   Print('Operace se nezdaøila');
	   rollback
	  END Catch
	 end
end

/*Aktualizace hráèe konkrétnì jeho jméno*/
alter procedure ChangeName @oldName VARCHAR(30), @newName VARCHAR(30)
as
begin
IF(EXISTS(SELECT nick_name FROM hrac where Nick_name = @newName))
 begin
  print('Hráè se jménem: '+@newName+' existuje');
 end 
  else
   begin
    UPDATE HRAC set Nick_name = @newName where Nick_name=@oldName
	UPDATE zapasy_hracu set HracA = @newName where HracA=@oldName
	UPDATE Zapasy_hracu set HracB = @newName where HracB=@oldName

   end
end

 /*Vyhledání hráèe*/
ALTER procedure [dbo].[FindPlayer] @parametr Varchar(50) = null
as
begin
 if(@parametr is not NULL)
  begin
   SELECT nick_name, dh.p_Her, r.nazev as "Rank", ISNULL(t.Nazev_tymu, 'Nepripojen') as Nazev_Tymu from tym t
   LEFT JOIN TymHrac th on th.Tym_tID =t.tID
   right JOIN hrac h on h.hID=th.Hrac_hID
   JOIN Nastaveni_Hrace n on h.hID= n.hId 
   JOIN Detail_Hrace dh on dh.hID= h.hID
   JOIN "rank" r on r.rID = dh.rID
   and (h.Nick_name like @parametr or n.Jmeno like @parametr or Lokace like @parametr);
  end
 else 
  begin
    SELECT nick_name, dh.p_Her, r.nazev as "Rank",ISNULL(t.Nazev_tymu, 'Nepripojen') as Nazev_Tymu from tym t
   LEFT JOIN TymHrac th on th.Tym_tID =t.tID
   right JOIN hrac h on h.hID=th.Hrac_hID
   JOIN Nastaveni_Hrace n on h.hID= n.hId 
   JOIN Detail_Hrace dh on dh.hID= h.hID
   JOIN "rank" r on r.rID = dh.rID 

 end
end

/*Seznam zápasù týmu*/
create procedure ListOfTymZapas @parametr DATETIME = null
as
begin
if(@parametr is not NULL)
 begin
  SELECT TymA, TymB, Datumzapasu FROM Zapasy_Tymu where Datumzapasu = @parametr;
 end
else 
  begin
   SELECT TymA, TymB, Datumzapasu FROM Zapasy_Tymu;
  end
end

 
 /*Seznam zápasù hráèù*/
 create procedure ListOfHracZapas @parametr DATETIME = null
as
begin
if(@parametr is not NULL)
 begin
  select HracA,HracB,Datum_Zapasu from Zapasy_hracu where Datum_zapasu = @parametr;
 end
else 
  begin
   select HracA,HracB,Datum_Zapasu from Zapasy_hracu;
  end
end
exec ListOfHracZapas
select * from Zapasy_tymu
select * from Detail_Hrace

 SELECT nick_name, dh.p_Her, dh.p_Vyher,dh.skore,ISNULL(dh.Pozice,0) as 'pozice', r.nazev as "Rank",ISNULL(t.Nazev_tymu, 'Nepripojen') as Nazev_Tymu from tym t
   LEFT JOIN TymHrac th on th.Tym_tID =t.tID
   right JOIN hrac h on h.hID=th.Hrac_hID
   JOIN Nastaveni_Hrace n on h.hID= n.hId 
   JOIN Detail_Hrace dh on dh.hID= h.hID
   JOIN "rank" r on r.rID = dh.rID and h.Nick_name ='Keiko'

   select Nazev_ligy,pozadavek,ISNULL(pocet_hracu,0) as Pocet_hracu,"status",Vyhra,Datum_zacatku,Datum_Konce from Liga_hracu




/*Vytvoreni tymu*/
alter procedure CreateTeam @Name VARCHAR(50), @popis Varchar(150)
as
 begin
 Declare @id VARCHAR(1000);
 IF NOT EXISTS(SELECT Nazev_tymu from Tym where Nazev_tymu=@Name)
   begin
   Begin try
   Begin tran
     INSERT INTO Detail_tymu(pocet_her,pocet_vyher,popis,Pozice,pocet_hracu) Values(0,0,@popis,NULL,0);
	 set @id =(SELECT top 1 dtId from Detail_tymu order by dtId desc);
     INSERT INTO Tym (dtId,Nazev_tymu) VALUES(@id,@Name);	
	 print('Tým vytvoøen');
	commit 
	end try
	Begin catch
	 print ('Operace se neprovedla');
	 rollback
	End catch
   end
  else
   begin
   print('Tym se jmenem: '+@Name+' již existuje');
   end
 end

/*Pøihlášení týmu do ligy */
alter procedure JoinToLiga @nameOfLiga VARCHAR(30), @team VARCHAR(30)
as
begin
 DECLARE @Pozadavek  VARCHAR(1000);
 set @Pozadavek =(select pozadavek from Liga_Tymu where Liga_Tymu.Nazev_ligy=@nameOfLiga);
 DECLARE @pocet INT;
 Declare @pom VARCHAR(1000);
 begin
  set @pocet =  (select count(*) from Tym t JOIN TymHrac th on th.Tym_tID = t.tID and Nazev_tymu =@team);
 if(NOT EXISTS(SELECT nazev_tymu from tym t join Liga_Tymu lt on t.lID = lt.lID and Nazev_tymu = @team))
  begin
  if(@pozadavek = 'Alespon 5 lidi')
   begin
    if(@pocet >= 5)
	 begin
	  UPDATE Tym set lID = (select lID from Liga_Tymu where Nazev_ligy = @nameOfLiga)
	  print('Uspech');
	 end   
	 else
	 begin
	  print('Pocet hracu v tymu: '+@team+' Je maly');
	 end
    end
	 else
   begin
    UPDATE Tym set lID = (select lID from Liga_Tymu where Nazev_ligy = @nameOfLiga)
   end
   end
   else 
    begin
	 print('Team: '+@team+' jiz v lize existuje');
	end
  end
end

/*Vytvoreni ligy*/
alter Procedure CreateLiga @table VARCHAR(50),@name VARCHAR(50), @pozadavek VARCHAR(100), @Status VARCHAR(30), @Vyhra VARCHAR(30), @od DATETIME, @do DATETIME
as
begin
	if((@table ='Týmová liga'))
	begin
	  if(NOT EXISTS(SELECT nazev_ligy from Liga_Tymu where Nazev_ligy = @name))
		begin
		 begin tran
		  begin try
			INSERT INTO Liga_tymu (Nazev_ligy, Pozadavek, poc_tymu, "status",Vyhra,Datum_zacatku, Datum_konce)
			VALUES (@name, @pozadavek, 2,@Status,@vyhra,@od,@do);
			commit
			print @name+' Byla uspesne vytvorena';
			end try
			begin catch
			 print('Chyba');
			end catch
		end
		else 
		    print('Liga se jmenem: '+@name+' jiz existuje')
	end
    else if(@table ='Hráèská liga')
		begin
		 if(NOT EXISTS(SELECT nazev_ligy from Liga_hracu where Nazev_ligy = @name))
		  begin
		   begin tran
		    begin try
			 INSERT INTO Liga_hracu (Nazev_ligy, Pozadavek, pocet_hracu, "status",Datum_zacatku, Datum_konce,Vyhra)
			 VALUES (@name, @pozadavek, 2,@Status,@od,@do,@Vyhra);
			 commit;
				print @name+' Byla uspesne vytvorena';
			end try
			begin catch
			  print('Chyba');
			end catch
		  end
		  else
		    begin
			 print('Liga se jmenem: '+@name+' jiz existuje')
		    end
	end
end

