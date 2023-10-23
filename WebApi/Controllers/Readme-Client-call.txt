HttpResponseMessage response = await Http.GetAsync(myapiroute);
IEnumerable<Staff> staff = response.Content.ReadFromJsonAsync<IEnumerable<Staff>>(
    new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve });