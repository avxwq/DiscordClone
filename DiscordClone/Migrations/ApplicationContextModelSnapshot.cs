﻿// <auto-generated />
using System;
using DiscordClone.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiscordClone.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiscordClone.Models.Attachment", b =>
                {
                    b.Property<Guid>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttachmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AttachmentId");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("DiscordClone.Models.Channel", b =>
                {
                    b.Property<Guid>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChannelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChannelId");

                    b.HasIndex("ServerId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("DiscordClone.Models.ChannelPermission", b =>
                {
                    b.Property<Guid>("ChannelPermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChannelPermissionId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("ChannelPermissions");
                });

            modelBuilder.Entity("DiscordClone.Models.DirectMessage", b =>
                {
                    b.Property<Guid>("DirectMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DirectMessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("DirectMessages");
                });

            modelBuilder.Entity("DiscordClone.Models.Invite", b =>
                {
                    b.Property<Guid>("InviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InviterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InviteId");

                    b.HasIndex("InviterId");

                    b.HasIndex("ServerId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("DiscordClone.Models.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DiscordClone.Models.MessageEditHistory", b =>
                {
                    b.Property<Guid>("EditHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OldContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EditHistoryId");

                    b.HasIndex("MessageId");

                    b.ToTable("messageEditHistories");
                });

            modelBuilder.Entity("DiscordClone.Models.Poll", b =>
                {
                    b.Property<Guid>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PollId");

                    b.HasIndex("ChannelId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("DiscordClone.Models.PollOption", b =>
                {
                    b.Property<Guid>("PollOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PollId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PollOptionId");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("DiscordClone.Models.PollVote", b =>
                {
                    b.Property<Guid>("PollVoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PollId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PollOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PollVoteId");

                    b.HasIndex("PollId");

                    b.HasIndex("PollOptionId");

                    b.HasIndex("UserId");

                    b.ToTable("PollVotes");
                });

            modelBuilder.Entity("DiscordClone.Models.Reaction", b =>
                {
                    b.Property<Guid>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReactionId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("DiscordClone.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.HasIndex("ServerId");

                    b.ToTable("ServersRoles");
                });

            modelBuilder.Entity("DiscordClone.Models.Server", b =>
                {
                    b.Property<Guid>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("DiscordClone.Models.ServerBan", b =>
                {
                    b.Property<Guid>("BanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BannedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BanId");

                    b.HasIndex("ServerId");

                    b.HasIndex("UserId");

                    b.ToTable("ServerBans");
                });

            modelBuilder.Entity("DiscordClone.Models.ServerMember", b =>
                {
                    b.Property<Guid>("ServerMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMuted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServerMemberId");

                    b.HasIndex("ServerId");

                    b.HasIndex("UserId");

                    b.ToTable("ServerMembers");
                });

            modelBuilder.Entity("DiscordClone.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DiscordClone.Models.UserActivityLog", b =>
                {
                    b.Property<Guid>("ActivityLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActivityLogId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivityLogs");
                });

            modelBuilder.Entity("DiscordClone.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserServerRole");
                });

            modelBuilder.Entity("DiscordClone.Models.VoiceSession", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMuted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeftAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("VoiceSessions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DiscordClone.Models.Attachment", b =>
                {
                    b.HasOne("DiscordClone.Models.Message", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("DiscordClone.Models.Channel", b =>
                {
                    b.HasOne("DiscordClone.Models.Server", "Server")
                        .WithMany("Channels")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiscordClone.Models.ChannelPermission", b =>
                {
                    b.HasOne("DiscordClone.Models.Channel", "Channel")
                        .WithMany("ChannelPermissions")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Channel");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.DirectMessage", b =>
                {
                    b.HasOne("DiscordClone.Models.User", "Receiver")
                        .WithMany("ReceivedDirectMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "Sender")
                        .WithMany("SentDirectMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DiscordClone.Models.Invite", b =>
                {
                    b.HasOne("DiscordClone.Models.User", "Inviter")
                        .WithMany()
                        .HasForeignKey("InviterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.Server", "Server")
                        .WithMany("Invites")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inviter");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiscordClone.Models.Message", b =>
                {
                    b.HasOne("DiscordClone.Models.Channel", "Channel")
                        .WithMany("Messages")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.MessageEditHistory", b =>
                {
                    b.HasOne("DiscordClone.Models.Message", "Message")
                        .WithMany("EditHistory")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("DiscordClone.Models.Poll", b =>
                {
                    b.HasOne("DiscordClone.Models.Channel", "Channel")
                        .WithMany("Polls")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("DiscordClone.Models.PollOption", b =>
                {
                    b.HasOne("DiscordClone.Models.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("DiscordClone.Models.PollVote", b =>
                {
                    b.HasOne("DiscordClone.Models.Poll", "Poll")
                        .WithMany("Votes")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.PollOption", "PollOption")
                        .WithMany()
                        .HasForeignKey("PollOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");

                    b.Navigation("PollOption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.Reaction", b =>
                {
                    b.HasOne("DiscordClone.Models.Message", "Message")
                        .WithMany("Reactions")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.Role", b =>
                {
                    b.HasOne("DiscordClone.Models.Server", "Server")
                        .WithMany("Roles")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiscordClone.Models.Server", b =>
                {
                    b.HasOne("DiscordClone.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DiscordClone.Models.ServerBan", b =>
                {
                    b.HasOne("DiscordClone.Models.Server", "Server")
                        .WithMany("Bans")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.ServerMember", b =>
                {
                    b.HasOne("DiscordClone.Models.Server", "Server")
                        .WithMany("ServerMembers")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany("ServerMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.UserActivityLog", b =>
                {
                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.UserRole", b =>
                {
                    b.HasOne("DiscordClone.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscordClone.Models.VoiceSession", b =>
                {
                    b.HasOne("DiscordClone.Models.Channel", "Channel")
                        .WithMany("VoiceSessions")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", "User")
                        .WithMany("VoiceSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DiscordClone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DiscordClone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscordClone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DiscordClone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordClone.Models.Channel", b =>
                {
                    b.Navigation("ChannelPermissions");

                    b.Navigation("Messages");

                    b.Navigation("Polls");

                    b.Navigation("VoiceSessions");
                });

            modelBuilder.Entity("DiscordClone.Models.Message", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("EditHistory");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("DiscordClone.Models.Poll", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("DiscordClone.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DiscordClone.Models.Server", b =>
                {
                    b.Navigation("Bans");

                    b.Navigation("Channels");

                    b.Navigation("Invites");

                    b.Navigation("Roles");

                    b.Navigation("ServerMembers");
                });

            modelBuilder.Entity("DiscordClone.Models.User", b =>
                {
                    b.Navigation("ActivityLogs");

                    b.Navigation("Messages");

                    b.Navigation("Reactions");

                    b.Navigation("ReceivedDirectMessages");

                    b.Navigation("SentDirectMessages");

                    b.Navigation("ServerMembers");

                    b.Navigation("VoiceSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
