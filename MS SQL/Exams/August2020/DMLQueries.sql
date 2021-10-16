INSERT INTO Distributors VALUES 
('Deloitte & Touche','6 Arch St #9757','Customizable neutral traveling',2),
('Congress Title','58 Hancock St','Customer loyalty',13),
('Kitchen People','3 E 31st St #77','Triple-buffered stable delivery',1),
('General Color Co Inc','6185 Bohn St #72','Focus group',21),
('Beck Corporation','21 E 64th Ave','Quality-focused 4th generation hardware',23)

INSERT INTO Customers VALUES
('Francoise','Rautenstrauch','M',15,'0195698399',5),
('Kendra','Loud','F',22,'0063631526',11),
('Lourdes','Bauswell','M',50,'0139037043',8),
('Hannah','Edmison','F',18,'0043343686',1),
('Tom','Loeza','M',31,'0144876096',23),
('Queenie','Kramarczyk','F',30,'0064215793',29),
('Hiu','Portaro','M',25,'0068277755',16),
('Josefa','Opitz','F',43,'0197887645',17)

---

UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

---


DELETE Feedbacks
WHERE CustomerId = 14 OR ProductId = 5
