﻿SELECT * FROM "data_all" 
WHERE passenger_document_number = (
	SELECT passenger_document_number FROM "data_all"
	WHERE ticket_number = {0}
	LIMIT(1));