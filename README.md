# Library WebAPI
This is an ASP.NET Core WebAPI application with a 3-layer architecture and an in memory database.

## Functionality
### 1. Get all books. Order by provided value (title or author)
**GET** https://{{baseUrl}}/api/books?order=author

Response
```
[{
	"id": "number",
	"title": "string",
	"author": "string",
	"rating": "decimal",    //average rating
	"reviewsNumber": "decimal"    //count of reviews
}]
```

### 2. Get top 10 books with high rating and number of reviews greater than 10. You can filter books by specifying genre. Order by rating
**GET** https://{{baseUrl}}/api/recommended?genre=horror

Response
```
[{
	"id": "number",
	"title": "string",
	"author": "string",
	"rating": "decimal",    //average rating
	"reviewsNumber": "decimal"    //count of reviews
}]
```

### 3. Get book details with the list of reviews
**GET** https://{{baseUrl}}/api/books/{id}

Response
```
{
	"id": "number",
	"title": "string",
	"author": "string",
	"cover": "string",
	"content": "string",
	"rating": "decimal",    //average rating
	"reviews": [{
		"id": "number",
		"message": "string",
		"reviewer": "string",
	}]
}
```

### 4. Delete a book using a secret key. The secret key is stored in the config applications.
**DELETE** https://{{baseUrl}}/api/books/{id}?secret=qwerty

### 5. Save a new book.
**POST** https://{{baseUrl}}/api/books/save
```
{
	"id": "number", 
	"title": "string",
	"cover": "string",
	"content": "string",
	"genre": "string",
	"author": "string"
}
```

Response
```
{
	"id": "number"
}
```

### 6. Save a review for the book.
**PUT** https://{{baseUrl}}/api/books/{id}/review
```
{
	"message": "string",
	"reviewer": "string"
}
```

### 7. Rate a book
**PUT** https://{{baseUrl}}/api/books/{id}/rate
```
{
	"score": "number",    // score can be from 1 to 5
}
```

