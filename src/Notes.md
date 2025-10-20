# API

## HTTP request pipeline

```cpp
var app = builder.Build(); 

// START PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");
app.MapControllers();
// END PIPELINE

app.Run(); 
```

After building and before running the app, the middleware pipeline is configured. Order matters!