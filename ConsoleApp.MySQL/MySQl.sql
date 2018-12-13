 SELECT * FROM test.datalog where type='Event';
 
 CREATE INDEX IX_TYPE ON test.datalog(type(20)); 
 /*DROP INDEX [indexName] ON mytable; */