using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // apply migrations if not done

    // Seed if empty
    if (!db.PageSections.Any())
    {
        // -----------------------
        // HERO SLIDES
        // -----------------------
        var hero1 = new MediaItem
        {
            FileName = "hero1.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/hero1.jpg",
            AltText = "Modern workspace"
        };
        var hero2 = new MediaItem
        {
            FileName = "hero2.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/hero2.jpg",
            AltText = "Conference room"
        };
        var hero3 = new MediaItem
        {
            FileName = "hero3.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/hero3.jpg",
            AltText = "Office lounge"
        };
        db.MediaItems.AddRange(hero1, hero2, hero3);
        db.SaveChanges();

        db.PageSections.AddRange(
            new PageSection
            {
                Title = "Creating Exceptional Workspaces",
                Body = "Specialists in transforming commercial spaces into agile, functional and empowering environments.",
                HtmlTag = "h1",
                MediaItemId = hero1.Id,
                SortOrder = 1
            },
            new PageSection
            {
                Title = "Design for Collaboration",
                Body = "Furniture and interiors that make teamwork effortless.",
                HtmlTag = "h1",
                MediaItemId = hero2.Id,
                SortOrder = 2
            },
            new PageSection
            {
                Title = "Workspaces that Inspire",
                Body = "Sustainable solutions for the modern workplace.",
                HtmlTag = "h1",
                MediaItemId = hero3.Id,
                SortOrder = 3
            }
        );
        db.SaveChanges();

        // -----------------------
        // CUSTOM DESIGN CIRCLES SECTION
        // -----------------------
        db.PageSections.Add(new PageSection
        {
            Title = "Custom built design & furniture solutions",
            Body = "Specialists in transforming commercial spaces into agile, functional and empowering environments.",
            HtmlTag = "h2",
            SortOrder = 4
        });
        db.SaveChanges();

        // -----------------------
        // LATEST WORK / PROJECTS
        // -----------------------
        var project1 = new MediaItem
        {
            FileName = "project1.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/project1.jpg",
            AltText = "Case Study One"
        };
        var project2 = new MediaItem
        {
            FileName = "project2.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/project2.jpg",
            AltText = "Case Study Two"
        };
        var project3 = new MediaItem
        {
            FileName = "project3.jpg",
            ContentType = "image/jpeg",
            Url = "/uploads/project3.jpg",
            AltText = "Case Study Three"
        };
        db.MediaItems.AddRange(project1, project2, project3);
        db.SaveChanges();

        db.PageSections.AddRange(
            new PageSection
            {
                Title = "Case Study Name Here",
                Body = "Description for project one.",
                HtmlTag = "h3",
                MediaItemId = project1.Id,
                SortOrder = 5
            },
            new PageSection
            {
                Title = "Case Study Name Here",
                Body = "Description for project two.",
                HtmlTag = "h3",
                MediaItemId = project2.Id,
                SortOrder = 6
            },
            new PageSection
            {
                Title = "Case Study Name Here",
                Body = "Description for project three.",
                HtmlTag = "h3",
                MediaItemId = project3.Id,
                SortOrder = 7
            }
        );

        db.SaveChanges();
    }
}
