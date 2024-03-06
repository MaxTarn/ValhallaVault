﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValhallaVault.Data;

#nullable disable

namespace ValhallaVault.Migrations.ProgramDb
{
    [DbContext(typeof(ProgramDbContext))]
    [Migration("20240306145145_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ValhallaVault.Data.Models.AnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Ett potentiellt telefonbedrägeri",
                            IsCorrect = true,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Ett legitimt försök från banken att skydda ditt konto",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Answer = "En informationsinsamling för en marknadsundersökning",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Ett romansbedrägeri",
                            IsCorrect = true,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 5,
                            Answer = "En legitim begäran om hjälp från en person i nöd",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 6,
                            Answer = "Investeringsbedrägeri",
                            IsCorrect = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 7,
                            Answer = "Genomföra omedelbar investering för att inte missa möjligheten",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 8,
                            Answer = "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst",
                            IsCorrect = true,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 9,
                            Answer = "Återgå till kontorsarbete",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 10,
                            Answer = "Förbjuda användning av personliga enheter för arbete",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 11,
                            Answer = "Organiserade cyberbrottsliga grupper",
                            IsCorrect = true,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 12,
                            Answer = "En enskild hackare med ett personligt vendetta",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 13,
                            Answer = "Implementera en ny brandvägg",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 14,
                            Answer = "Slå på tvåfaktorsautentisering för alla fjärranslutningar",
                            IsCorrect = true,
                            QuestionId = 5
                        },
                        new
                        {
                            Id = 15,
                            Answer = "Skriv ut alla dokument och undvik digital delning",
                            IsCorrect = false,
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 16,
                            Answer = "Använd samma lösenord för alla konton för enkelhetens skull",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 17,
                            Answer = "Social engineering",
                            IsCorrect = true,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 18,
                            Answer = "Stark kryptering",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 19,
                            Answer = "Brandväggar",
                            IsCorrect = false,
                            QuestionId = 8
                        });
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Att skydda sig mot Bedrägerier"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cybersäkerhet för företag"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cyberspionage"
                        });
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Explanation = "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.",
                            Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...",
                            SubcategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Explanation = "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.",
                            Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...",
                            SubcategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            Explanation = "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.",
                            Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...",
                            SubcategoryId = 3
                        },
                        new
                        {
                            Id = 4,
                            Explanation = "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö.",
                            Question = "Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?",
                            SubcategoryId = 14
                        },
                        new
                        {
                            Id = 5,
                            Explanation = "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård.",
                            Question = "Vilken typ av angrepp har de sannolikt blivit utsatta för?",
                            SubcategoryId = 15
                        },
                        new
                        {
                            Id = 6,
                            Explanation = "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system.",
                            Question = "Vilken typ av malware var primärt ansvarig för denna incident?",
                            SubcategoryId = 16
                        },
                        new
                        {
                            Id = 7,
                            Explanation = "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper.",
                            Question = "Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?",
                            SubcategoryId = 17
                        },
                        new
                        {
                            Id = 8,
                            Explanation = "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor.",
                            Question = "Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?",
                            SubcategoryId = 18
                        },
                        new
                        {
                            Id = 9,
                            Explanation = "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot.",
                            Question = "Vilken lagstiftning ger ramverket för detta skydd?",
                            SubcategoryId = 19
                        });
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Segments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Del 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Del 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Del 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Del 1"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "Del 2"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Name = "Del 1"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "Del 2"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Name = "Del 3"
                        });
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SegmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kreditkortsbedrägeri",
                            SegmentId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Romansbedrägeri",
                            SegmentId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Investeringsbedrägeri",
                            SegmentId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Telefonbedrägeri",
                            SegmentId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Digital säkerhet på företag",
                            SegmentId = 4
                        },
                        new
                        {
                            Id = 6,
                            Name = "Risker och beredskap",
                            SegmentId = 4
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cyberangrepp mot känsliga sektorer",
                            SegmentId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Allmänt om cyberspionage",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 9,
                            Name = "Metoder för cyberspionage",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 10,
                            Name = "Säkerhetsskyddslagen",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cyberspionagets aktörer",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 12,
                            Name = "Social engineering",
                            SegmentId = 7
                        },
                        new
                        {
                            Id = 13,
                            Name = "Virus, maskar och trojaner",
                            SegmentId = 8
                        },
                        new
                        {
                            Id = 14,
                            Name = "Abonnemangsfällor och falska fakturor",
                            SegmentId = 5
                        },
                        new
                        {
                            Id = 15,
                            Name = "Ransomware",
                            SegmentId = 5
                        },
                        new
                        {
                            Id = 16,
                            Name = "Statistik och förhållningssätt",
                            SegmentId = 5
                        },
                        new
                        {
                            Id = 17,
                            Name = "Utpressningsvirus",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 18,
                            Name = "Attacker mot servrar",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 19,
                            Name = "Cyberangrepp i Norden",
                            SegmentId = 6
                        },
                        new
                        {
                            Id = 20,
                            Name = "Varning för vishing",
                            SegmentId = 7
                        },
                        new
                        {
                            Id = 21,
                            Name = "Identifiera VD-mejl",
                            SegmentId = 7
                        },
                        new
                        {
                            Id = 22,
                            Name = "Öneangrepp och presentkortsbluffar",
                            SegmentId = 7
                        },
                        new
                        {
                            Id = 23,
                            Name = "Värvningsförsök",
                            SegmentId = 8
                        },
                        new
                        {
                            Id = 24,
                            Name = "Affärsspionage",
                            SegmentId = 8
                        },
                        new
                        {
                            Id = 25,
                            Name = "Påverkanskampanjer",
                            SegmentId = 8
                        });
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.AnswerModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.QuestionModel", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.SubcategoryModel", "Subcategory")
                        .WithMany("Questions")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.CategoryModel", "Category")
                        .WithMany("Segments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.SegmentModel", "Segment")
                        .WithMany("Subcategories")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.CategoryModel", b =>
                {
                    b.Navigation("Segments");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
